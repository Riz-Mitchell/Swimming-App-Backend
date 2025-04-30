using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Domain.Helpers;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ISwimRepository
    {
        Task<List<GetSwimResDTO>> GetSwimsByQueryAsync(GetSwimsQuery query);
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id);
        Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId);
        // Task<GetSwimResDTO?> UpdateSwimAsync(Guid id, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid swimId, Guid userId);
        Task<double?> PercentageOffPBTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId);
        double? PercentageOffPBTimeStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId);
        Task<double?> PercentageOffGoalTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId);
        double? PercentageOffGoalTimeStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId);
        Task<double?> GetPotentialRaceTime(CreateSwimReqDTO swimSchema);

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
                Event = swim.Event,
                PercentageOffPBTime = swim.PercentageOffPBTime,
                PercentageOffPBStrokeRate = swim.PercentageOffPBStrokeRate,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations       // Need to implement these calculations
                PotentialRaceTime = swim.PotentialRaceTime,
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
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
                Event = foundSwim.Event,
                Distance = foundSwim.Distance,
                PercentageOffPBTime = foundSwim.PercentageOffPBTime,
                PercentageOffPBStrokeRate = foundSwim.PercentageOffPBStrokeRate,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations       // Need to implement these calculations
                PotentialRaceTime = foundSwim.PotentialRaceTime,
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
                PerceivedExertion = foundSwim.PerceivedExertion,
                Dive = foundSwim.Dive,
                GoalSwim = foundSwim.GoalSwim,
                RecordedAt = foundSwim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema, Guid athleteDataOwnerId)
        {
            var foundAthlete = await _context.AthleteDatas
                .Include(a => a.Swims)
                .FirstOrDefaultAsync(a => a.Id == athleteDataOwnerId)
                ?? throw new Exception("Athlete not found");

            Console.WriteLine($"Number of records in timesheet {await _context.TimeSheets.CountAsync()}");

            var swim = new Swim
            {
                Time = swimSchema.Time,
                Stroke = swimSchema.Stroke,
                Distance = swimSchema.Distance,
                Event = swimSchema.Event,
                PercentageOffPBTime = await PercentageOffPBTime(swimSchema, foundAthlete, athleteDataOwnerId),
                PercentageOffPBStrokeRate = PercentageOffPBTimeStrokeRate(swimSchema, foundAthlete, athleteDataOwnerId),
                PercentageOffGoalTime = await PercentageOffGoalTime(swimSchema, foundAthlete, athleteDataOwnerId),
                PercentageOffGoalStrokeRate = PercentageOffGoalTimeStrokeRate(swimSchema, foundAthlete, athleteDataOwnerId),         // Need to implement these calculations
                PotentialRaceTime = await GetPotentialRaceTime(swimSchema),
                StrokeRate = swimSchema.StrokeRate ?? null,
                StrokeCount = swimSchema.StrokeCount ?? null,
                PerceivedExertion = swimSchema.PerceivedExertion ?? null,
                Dive = swimSchema.Dive ?? false,
                AthleteDataOwnerId = athleteDataOwnerId,
                AthleteDataOwner = foundAthlete
            };
            foundAthlete.Swims.Add(swim);

            _context.Swims.Add(swim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = swim.Id,
                Time = swim.Time,
                Stroke = swim.Stroke,
                Event = swim.Event,
                Distance = swim.Distance,
                PercentageOffPBTime = swim.PercentageOffPBTime,
                PercentageOffPBStrokeRate = swim.PercentageOffPBStrokeRate,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PotentialRaceTime = swim.PotentialRaceTime,
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
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
            foundSwim.PerceivedExertion = updateSchema.PerceivedExertion ?? foundSwim.PerceivedExertion;
            foundSwim.Dive = updateSchema.Dive ?? foundSwim.Dive;

            _context.Swims.Update(foundSwim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Time = foundSwim.Time,
                Stroke = foundSwim.Stroke,
                Event = foundSwim.Event,
                Distance = foundSwim.Distance,
                PercentageOffPBTime = foundSwim.PercentageOffPBTime,
                PercentageOffPBStrokeRate = foundSwim.PercentageOffPBStrokeRate,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PotentialRaceTime = foundSwim.PotentialRaceTime,
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
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

        public async Task<double?> PercentageOffPBTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId)
        {
            var swimsInSameEvent = athleteData.Swims
                .Where(s => s.Event == swimSchema.Event && s.GoalSwim == false)
                .ToList();

            foreach (var swim in swimsInSameEvent)
            {
                Console.WriteLine($"Swim: {swim.Id}, Time: {swim.Time}, Event: {swim.Event}, Distance: {swim.Distance}");
            }

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                Console.WriteLine("Returning null for PercentageOffPBTime 1");
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var eventPB = swimsInSameEvent
                    .Where(s => s.Distance == EventHelper.GetDistance(swimSchema.Event))
                    .Select(s => (double?)s.Time)
                    .Min();

                // If there is a PB for the event
                if (eventPB.HasValue)
                {
                    if (swimSchema.Distance == EventHelper.GetDistance(swimSchema.Event))
                    {
                        return (swimSchema.Time - eventPB) / eventPB * 100;
                    }
                    else
                    {
                        var foundTimeSheet = await _context.TimeSheets
                            .FirstOrDefaultAsync(ts => ts.Event == swimSchema.Event) ?? throw new Exception("Time sheet not found");

                        var potentialRaceTime = InterpolationHelper.GetPotentialRaceTime(foundTimeSheet.SplitDataForTimes, swimSchema.Time, swimSchema.Distance);




                        return (potentialRaceTime - eventPB) / eventPB * 100;
                    }
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffPBTime 2");
                    return null;
                }
            }
        }

        public double? PercentageOffPBTimeStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId)
        {
            if (swimSchema.StrokeRate == null)
            {
                Console.WriteLine("Returning null for PercentageOffPBStrokeRate 1");
                return null;        // Stroke rate does not exist thus there is no comparison
            }

            var swimsInSameEvent = athleteData.Swims
                .Where(s => s.Event == swimSchema.Event && s.GoalSwim == false)
                .ToList();

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var eventPBSwim = swimsInSameEvent
                    .Where(s => s.Distance == EventHelper.GetDistance(swimSchema.Event))
                    .OrderBy(s => s.Time)
                    .FirstOrDefault();

                if (eventPBSwim == null)
                {
                    Console.WriteLine("No recorded PB swim found for this event");
                    return null;        // Pb does not exist thus there is no comparison
                }

                var eventPBStrokeRate = eventPBSwim.StrokeRate;

                if (eventPBStrokeRate == null)
                {
                    Console.WriteLine("PB Swim does not have a stroke rate");
                    return null;
                }

                if (eventPBStrokeRate.HasValue)
                {
                    Console.WriteLine($"Event PB Stroke Rate: {eventPBStrokeRate}");
                    Console.WriteLine($"Swim Schema Stroke Rate: {swimSchema.StrokeRate}");
                    Console.WriteLine($"Returning equation ({swimSchema.StrokeRate} - {eventPBStrokeRate}) / {eventPBStrokeRate} * 100");
                    Console.WriteLine($"Returning: {(swimSchema.StrokeRate - eventPBStrokeRate) / eventPBStrokeRate * 100}");
                    double percentage = (double)((double)(swimSchema.StrokeRate - eventPBStrokeRate) / eventPBStrokeRate * 100);
                    return percentage;
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffPBStrokeRate 2");
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffGoalTime(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId)
        {
            var goalTimes = athleteData.Swims
                .Where(s => s.Event == swimSchema.Event && s.GoalSwim == true)
                .ToList();

            if (goalTimes.Count == 0 || goalTimes == null)
            {
                Console.WriteLine("Returning null for PercentageOffGoalTime 1");
                return null;        // Goal time does not exist thus there is no comparison
            }
            else
            {
                var goalSwim = goalTimes
                    .Where(s => s.Distance == EventHelper.GetDistance(swimSchema.Event))
                    .OrderBy(s => s.Time)
                    .FirstOrDefault();

                var goalTime = goalSwim?.Time;

                if (goalSwim != null)
                {
                    if (goalSwim.Distance == EventHelper.GetDistance(swimSchema.Event))
                    {
                        return (swimSchema.Time - goalTime) / goalTime * 100;
                    }
                    else
                    {
                        var foundTimeSheet = await _context.TimeSheets
                            .FirstOrDefaultAsync(ts => ts.Event == swimSchema.Event) ?? throw new Exception("Time sheet not found");

                        var potentialRaceTime = InterpolationHelper.GetPotentialRaceTime(foundTimeSheet.SplitDataForTimes, swimSchema.Time, swimSchema.Distance);




                        return (potentialRaceTime - goalTime) / goalTime * 100;
                    }
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffGoalTime 2");
                    return null;
                }
            }
        }

        public double? PercentageOffGoalTimeStrokeRate(CreateSwimReqDTO swimSchema, AthleteData athleteData, Guid athleteDataOwnerId)
        {
            if (swimSchema.StrokeRate == null)
            {
                return null;        // Stroke rate is not provided thus there is no comparison
            }
            var goalSwimList = athleteData.Swims
                .Where(s => s.Event == swimSchema.Event && s.GoalSwim == true)
                .ToList();

            if (goalSwimList.Count == 0 || goalSwimList == null)
            {
                Console.WriteLine("Returning null for PercentageOffGoalStrokeRate 1");
                return null;        // Goal stroke rate does not exist thus there is no comparison
            }

            if (goalSwimList.Count > 1)
            {
                throw new Exception("Multiple goal swims found for the same event");
            }
            else
            {
                var goalSwim = goalSwimList
                    .Where(s => s.Distance == EventHelper.GetDistance(swimSchema.Event))
                    .OrderBy(s => s.Time)
                    .FirstOrDefault();

                if (goalSwim == null)
                {
                    Console.WriteLine("No recorded goal swim found for this event");
                    return null;        // Goal stroke rate does not exist thus there is no comparison
                }
                var goalStrokeRate = goalSwim.StrokeRate;

                if (goalStrokeRate == null)
                {
                    Console.WriteLine("Goal Swim does not have a stroke rate");
                    return null;
                }

                if (goalStrokeRate.HasValue)
                {
                    double percentage = (double)((double)(swimSchema.StrokeRate - goalStrokeRate) / goalStrokeRate * 100);

                    return percentage;
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffGoalStrokeRate 2");
                    return null;
                }
            }
        }

        public async Task<double?> GetPotentialRaceTime(CreateSwimReqDTO swimSchema)
        {
            if (swimSchema.Distance != EventHelper.GetDistance(swimSchema.Event))
            {
                var foundTimeSheet = await _context.TimeSheets
                    .FirstOrDefaultAsync(ts => ts.Event == swimSchema.Event) ?? throw new Exception("Time sheet not found");

                var potentialRaceTime = InterpolationHelper.GetPotentialRaceTime(foundTimeSheet.SplitDataForTimes, swimSchema.Time, swimSchema.Distance);
                return potentialRaceTime;
            }
            else
            {
                return null;        // No potential
            }
        }
    }
}