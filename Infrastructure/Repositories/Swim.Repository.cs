using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ISwimRepository
    {
        Task<List<GetSwimResDTO>> GetSwimsByQueryAsync(GetSwimsQuery query);
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id);
        Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId, Guid eventId);
        // Task<GetSwimResDTO?> UpdateSwimAsync(Guid id, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid swimId, Guid userId);
        Task<double?> PercentageOffPBTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId);
        Task<double?> PercentageOffPBStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId);
        Task<double?> PercentageOffGoalTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId);
        Task<double?> PercentageOffGoalStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId);
    }


    public class SwimRepository : ISwimRepository
    {
        private readonly SwimmingAppDBContext _context;

        public SwimRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetSwimResDTO>> GetSwimsByQueryAsync(GetSwimsQuery query)
        {
            var foundSwims = await _context.Swims
                .Where(x => query.Distance != null && x.Distance == query.Distance)
                .Skip((query.PageNumber - 1) * 10)
                .Take(10)
                .ToListAsync();

            var getSwimResDTOs = foundSwims.Select(swim => new GetSwimResDTO
            {
                Id = swim.Id,
                Time = swim.Time,
                Stroke = swim.Stroke,
                Distance = swim.Distance,
                PercentageOffPBTime = swim.PercentageOffPBTime,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations       // Need to implement these calculations
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
                Pace = swim.Pace,
                PerceivedExertion = swim.PerceivedExertion,
                Dive = swim.Dive,
                GoalSwim = swim.GoalSwim,
                RecordedAt = swim.RecordedAt
            }).ToList();

            return getSwimResDTOs;
        }

        public async Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim == null)
            {
                return null;
            }
            var getSwimResDTO = new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Time = foundSwim.Time,
                Stroke = foundSwim.Stroke,
                Distance = foundSwim.Distance,
                PercentageOffPBTime = foundSwim.PercentageOffPBTime,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations       // Need to implement these calculations
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
                Pace = foundSwim.Pace,
                PerceivedExertion = foundSwim.PerceivedExertion,
                Dive = foundSwim.Dive,
                GoalSwim = foundSwim.GoalSwim,
                RecordedAt = foundSwim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId, Guid eventId)
        {
            var foundAthlete = await _context.AthleteDatas.FindAsync(athleteDataOwnerId) ?? throw new Exception("Athlete not found");
            var swim = new Swim
            {
                Time = swimSchema.Time,
                Stroke = swimSchema.Stroke,
                Distance = swimSchema.Distance,
                PercentageOffPBTime = await PercentageOffPBTime(swimSchema, foundAthlete, athleteDataOwnerId, eventId),
                PercentageOffPBStrokeRate = await PercentageOffPBStrokeRate(swimSchema, foundAthlete, athleteDataOwnerId, eventId),
                PercentageOffGoalTime = await PercentageOffGoalTime(swimSchema, foundAthlete, athleteDataOwnerId, eventId),
                PercentageOffGoalStrokeRate = await PercentageOffGoalStrokeRate(swimSchema, foundAthlete, athleteDataOwnerId, eventId),         // Need to implement these calculations
                StrokeRate = swimSchema.StrokeRate ?? null,
                StrokeCount = swimSchema.StrokeCount ?? null,
                Pace = swimSchema.Pace ?? null,
                PerceivedExertion = swimSchema.PerceivedExertion ?? null,
                Dive = swimSchema.Dive ?? false,
                AthleteDataOwnerId = athleteDataOwnerId,
                AthleteDataOwner = foundAthlete,
                EventId = eventId,
                Event = await _context.Events.FindAsync(eventId) ?? throw new Exception("Event not found")
            };
            _context.Swims.Add(swim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = swim.Id,
                Time = swim.Time,
                Stroke = swim.Stroke,
                Distance = swim.Distance,
                PercentageOffPBTime = swim.PercentageOffPBTime,
                PercentageOffPBStrokeRate = swim.PercentageOffPBStrokeRate,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
                Pace = swim.Pace,
                PerceivedExertion = swim.PerceivedExertion,
                Dive = swim.Dive,
                GoalSwim = swim.GoalSwim,
                RecordedAt = swim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task<GetSwimResDTO?> UpdateSwimAsync(Guid id, UpdateSwimReqDTO updateSchema)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim == null)
            {
                return null;
            }

            foundSwim.Time = updateSchema.Time ?? foundSwim.Time;
            foundSwim.Stroke = updateSchema.Stroke ?? foundSwim.Stroke;
            foundSwim.Distance = updateSchema.Distance ?? foundSwim.Distance;
            foundSwim.StrokeRate = updateSchema.StrokeRate ?? foundSwim.StrokeRate;
            foundSwim.StrokeCount = updateSchema.StrokeCount ?? foundSwim.StrokeCount;
            foundSwim.Pace = updateSchema.Pace ?? foundSwim.Pace;
            foundSwim.PerceivedExertion = updateSchema.PerceivedExertion ?? foundSwim.PerceivedExertion;
            foundSwim.Dive = updateSchema.Dive ?? foundSwim.Dive;

            _context.Swims.Update(foundSwim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Time = foundSwim.Time,
                Stroke = foundSwim.Stroke,
                Distance = foundSwim.Distance,
                PercentageOffPBTime = foundSwim.PercentageOffPBTime,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
                Pace = foundSwim.Pace,
                PerceivedExertion = foundSwim.PerceivedExertion,
                Dive = foundSwim.Dive,
                GoalSwim = foundSwim.GoalSwim,
                RecordedAt = foundSwim.RecordedAt
            };

            return getSwimResDTO;
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

        public async Task<double?> PercentageOffPBTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId)
        {
            var foundEvent = await _context.Events.FindAsync(eventId) ?? throw new Exception("Event not found");
            var swimsInSameEvent = athleteData.Swims
                .Where(s => s.EventId == eventId && s.GoalSwim == false)
                .ToList();

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var eventPB = swimsInSameEvent
                    .Where(s => s.Distance == foundEvent.Distance)
                    .Select(s => (double?)s.Time)
                    .Min();

                // If there is a PB for the event
                if (eventPB.HasValue)
                {
                    if (swimSchema.Distance == foundEvent.Distance)
                    {
                        return (swimSchema.Time - eventPB) / eventPB * 100;
                    }
                    else
                    {
                        var timeSheetTime = foundEvent.TimeSheet.TimeSheetItems
                            .Where(tsi => tsi.CurrentInterval == swimSchema.Distance)
                            .Select(tsi => (double?)tsi.Time)
                            .FirstOrDefault() ?? throw new Exception("Time sheet not found");

                        return (swimSchema.Time - timeSheetTime) / timeSheetTime * 100;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffPBStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId)
        {
            if (swimSchema.StrokeRate == null)
            {
                return null;        // Stroke rate does not exist thus there is no comparison
            }

            var foundEvent = await _context.Events.FindAsync(eventId) ?? throw new Exception("Event not found");
            var swimsInSameEvent = athleteData.Swims
                .Where(s => s.EventId == eventId && s.GoalSwim == false)
                .ToList();

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var eventPBStrokeRate = swimsInSameEvent
                    .Where(s => s.Distance == foundEvent.Distance)
                    .Select(s => (double?)s.StrokeRate)
                    .Min();

                if (eventPBStrokeRate.HasValue)
                {
                    return (swimSchema.StrokeRate - eventPBStrokeRate) / eventPBStrokeRate * 100;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffGoalTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId)
        {
            var foundEvent = await _context.Events.FindAsync(eventId) ?? throw new Exception("Event not found");
            var goalTimes = athleteData.Swims
                .Where(s => s.EventId == eventId && s.GoalSwim == true)
                .ToList();

            if (goalTimes.Count == 0 || goalTimes == null)
            {
                return null;        // Goal time does not exist thus there is no comparison
            }
            else
            {
                var goalTime = goalTimes
                    .Where(s => s.Distance == foundEvent.Distance)
                    .Select(s => (double?)s.Time)
                    .Min();

                if (goalTime.HasValue)
                {
                    return (swimSchema.Time - goalTime) / goalTime * 100;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffGoalStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId, Guid eventId)
        {
            if (swimSchema.StrokeRate == null)
            {
                return null;        // Stroke rate is not provided thus there is no comparison
            }

            var foundEvent = await _context.Events.FindAsync(eventId) ?? throw new Exception("Event not found");
            var goalSwimList = athleteData.Swims
                .Where(s => s.EventId == eventId && s.GoalSwim == true)
                .ToList();

            if (goalSwimList.Count == 0 || goalSwimList == null)
            {
                return null;        // Goal stroke rate does not exist thus there is no comparison
            }

            if (goalSwimList.Count > 1)
            {
                throw new Exception("Multiple goal swims found for the same event");
            }
            else
            {
                var goalStrokeRate = goalSwimList
                    .Where(s => s.Distance == foundEvent.Distance)
                    .Select(s => (double?)s.StrokeRate)
                    .Min();

                if (goalStrokeRate.HasValue)
                {
                    return (swimSchema.StrokeRate - goalStrokeRate) / goalStrokeRate * 100;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}