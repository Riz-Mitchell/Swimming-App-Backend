using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Domain.Helpers;
using SwimmingAppBackend.Enum;
using Google.Apis.Logging;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ISwimRepository
    {
        Task<List<GetSwimResDTO>?> GetSwimsAsync(GetSwimsQuery query);
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id);
        Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId);
        Task<GetSwimResDTO?> UpdateSwimAsync(Guid swimId, Guid userId, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid swimId, Guid userId);
    }


    public class SwimRepository : ISwimRepository
    {
        private readonly SwimmingAppDBContext _context;
        private readonly ISplitRepository _splitRepository;

        public SwimRepository(SwimmingAppDBContext context, ISplitRepository splitRepository)
        {
            _splitRepository = splitRepository;
            _context = context;
        }

        public async Task<List<GetSwimResDTO>?> GetSwimsAsync(GetSwimsQuery query)
        {
            AthleteData? foundAthleteData = await _context.AthleteDatas
                .FirstOrDefaultAsync(a => a.UserOwnerId == query.UserId);

            if (foundAthleteData == null)
            {
                return null;
            }

            var swimsQuery = _context.Swims
                .Include(s => s.Splits)
                .Where(s => s.AthleteDataOwnerId == foundAthleteData.Id)
                .AsQueryable();

            if (query.Event != null)
            {
                swimsQuery = swimsQuery.Where(s => s.Event == query.Event);
            }

            if (query.OnlyPersonalBest == true)
            {
                swimsQuery = swimsQuery
                    .Where(swim => swim.Splits.Any(split => split.IntervalDistance == EventHelper.GetDistance(swim.Event)))
                    .GroupBy(swim => swim.Event)
                    .Select(g =>
                        g.OrderBy(swim =>
                            swim.Splits
                                .Where(split => split.IntervalDistance == EventHelper.GetDistance(swim.Event))
                                .Min(split => split.IntervalTime))
                        .First()
                );
            }

            if (query.OnlyGoalSwim == true)
            {
                swimsQuery = swimsQuery.Where(s => s.GoalSwim == true);
            }

            if (query.TimePeriod != null)
            {
                switch (query.TimePeriod)
                {
                    case TimePeriod.Day:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddDays(-1));
                        break;
                    case TimePeriod.Week:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddDays(-7));
                        break;
                    case TimePeriod.Month:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddMonths(-1));
                        break;
                    case TimePeriod.ThreeMonths:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddMonths(-3));
                        break;
                    case TimePeriod.SixMonths:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddMonths(-6));
                        break;
                    case TimePeriod.Year:
                        swimsQuery = swimsQuery.Where(s => s.RecordedAt >= DateTime.UtcNow.AddYears(-1));
                        break;
                }
            }

            if (query.OnlyDive == true)
            {
                swimsQuery = swimsQuery.Where(s => s.Splits.Any(split => split.Dive == true));
            }

            var swimsQueryResult = await swimsQuery
                .OrderByDescending(s => s.RecordedAt)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            if (swimsQueryResult == null || swimsQueryResult.Count == 0)
            {
                return [];
            }

            return swimsQueryResult.Select(swim => new GetSwimResDTO
            {
                Id = swim.Id,
                Event = swim.Event,
                GoalSwim = swim.GoalSwim,
                PoolType = swim.PoolType,
                SwimQuestionnaire = SwimQuestionnaireMapper.ModelToRes(swim.SwimQuestionnaire),
                RecordedAt = swim.RecordedAt
            ,
                Splits = SplitMapper.ListModelToListRes(swim.Splits)
            }).ToList();
        }

        public async Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim == null)
            {
                return null;
            }
            return new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Event = foundSwim.Event,
                GoalSwim = foundSwim.GoalSwim,
                PoolType = foundSwim.PoolType,
                RecordedAt = foundSwim.RecordedAt,
                SwimQuestionnaire = SwimQuestionnaireMapper.ModelToRes(foundSwim.SwimQuestionnaire),
                Splits = SplitMapper.ListModelToListRes(foundSwim.Splits)
            };
        }

        public async Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId)
        {
            bool athleteExists = await _context.AthleteDatas
                .AnyAsync(a => a.Id == athleteDataOwnerId);

            if (!athleteExists)
                throw new Exception("Athlete not found");

            SwimQuestionnaire swimQuestionnaire = new SwimQuestionnaire
            {
                SelfTalk = swimSchema.SwimQuestionnaire.SelfTalk,
                Nerves = swimSchema.SwimQuestionnaire.Nerves,
                EnergyLevel = swimSchema.SwimQuestionnaire.EnergyLevel,
                Breathing = swimSchema.SwimQuestionnaire.Breathing,
                CatchFeel = swimSchema.SwimQuestionnaire.CatchFeel,
                StrokeLength = swimSchema.SwimQuestionnaire.StrokeLength,
                KickTechnique = swimSchema.SwimQuestionnaire.KickTechnique,
                KickThroughout = swimSchema.SwimQuestionnaire.KickThroughout,
                HeadPosition = swimSchema.SwimQuestionnaire.HeadPosition,
                Turn = swimSchema.SwimQuestionnaire.Turn
            };

            Swim swim = new()
            {
                Event = swimSchema.Event,
                GoalSwim = swimSchema.GoalSwim,
                AthleteDataOwnerId = athleteDataOwnerId,
                SwimQuestionnaireId = swimQuestionnaire.Id,
                SwimQuestionnaire = swimQuestionnaire,
                PoolType = swimSchema.PoolType
            };

            _context.Swims.Add(swim);
            await _context.SaveChangesAsync();

            List<GetSplitResDTO> splitResDTOList = [];

            foreach (var splitSchema in swimSchema.Splits)
            {
                GetSplitResDTO splitRes = await _splitRepository.CreateSplitAsync(splitSchema, swim.Id, swim.Event, athleteDataOwnerId);
                splitResDTOList.Add(splitRes);
            }

            return new GetSwimResDTO
            {
                Id = swim.Id,
                Event = swim.Event,
                GoalSwim = swim.GoalSwim,
                PoolType = swim.PoolType,
                RecordedAt = swim.RecordedAt,
                SwimQuestionnaire = SwimQuestionnaireMapper.ModelToRes(swim.SwimQuestionnaire),
                Splits = splitResDTOList,
            };
        }

        public async Task<GetSwimResDTO?> UpdateSwimAsync(Guid swimId, Guid userId, UpdateSwimReqDTO updateSchema)
        {
            var foundSwim = await _context.Swims.FindAsync(swimId);

            if (foundSwim == null)
            {
                return null;
            }

            var foundAthleteDataId = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.AthleteDataId)
                .FirstOrDefaultAsync();

            if (foundSwim.AthleteDataOwnerId != foundAthleteDataId)
            {
                throw new Exception("User does not have permission to update this swim");
            }



            if (updateSchema.Event != foundSwim.Event)
            {
                Console.WriteLine($"Attempting to update swim with ID: {swimId}");

                // Console.WriteLine($"Event: {updateSchema.Event} Stroke: {updateSchema.Stroke}, Distance: {updateSchema.Distance}, Time: {updateSchema.Time}");
                // Recalculate the percentage off PB time
                /*


                PERFORM RECALCULATION OF percentages in the split models

                */
            }

            foundSwim.Event = updateSchema.Event ?? foundSwim.Event;
            // If goal swim is attempted being set to true, make sure there is only 1 goal swim for the Event right now
            foundSwim.GoalSwim = updateSchema.GoalSwim ?? foundSwim.GoalSwim;

            _context.Swims.Update(foundSwim);
            await _context.SaveChangesAsync();

            return new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Event = foundSwim.Event,
                GoalSwim = foundSwim.GoalSwim,
                PoolType = foundSwim.PoolType,
                RecordedAt = foundSwim.RecordedAt,
                SwimQuestionnaire = SwimQuestionnaireMapper.ModelToRes(foundSwim.SwimQuestionnaire),
                Splits = SplitMapper.ListModelToListRes(foundSwim.Splits)
            };
        }

        public async Task DeleteSwimAsync(Guid swimId, Guid userId)
        {
            var foundAthleteDataOwnerId = await _context.AthleteDatas
                .Where(ad => ad.UserOwnerId == userId)
                .Select(e => e.Id)
                .FirstOrDefaultAsync();

            var foundSwim = await _context.Swims.FindAsync(swimId);

            if (foundSwim != null && foundSwim.AthleteDataOwnerId == foundAthleteDataOwnerId)
            {
                _context.Swims.Remove(foundSwim);
                await _context.SaveChangesAsync();
            }
        }
    }
}
