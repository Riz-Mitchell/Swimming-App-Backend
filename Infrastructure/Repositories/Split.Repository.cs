using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Domain.Helpers;
using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ISplitRepository
    {
        Task<Split> CreateSplitAsyncNoSaveChanges(CreateSplitReqDTO splitSchema, Swim parentSwim, Guid athleteDataOwnerId);
        Task<double?> PercentageOffPBTime(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent);
        Task<double?> PercentageOffPBTimeStrokeRate(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent);
        Task<double?> PercentageOffGoalTime(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent);
        Task<double?> PercentageOffGoalTimeStrokeRate(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEventd);
        Task<double?> GetPotentialRaceTime(CreateSplitReqDTO splitSchema, EventEnum swimEvent);
    }

    public class SplitRepository : ISplitRepository
    {
        private readonly SwimmingAppDBContext _context;

        public SplitRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<Split> CreateSplitAsyncNoSaveChanges(CreateSplitReqDTO splitSchema, Swim parentSwim, Guid athleteDataOwnerId)
        {
            if (parentSwim == null || parentSwim.AthleteDataOwnerId != athleteDataOwnerId)
            {
                throw new Exception("Swim is null or does not belong to the specified athlete.");
            }

            var split = new Split
            {
                Stroke = splitSchema.Stroke,
                IntervalTime = splitSchema.IntervalTime,
                IntervalDistance = splitSchema.IntervalDistance,
                IntervalStrokeRate = splitSchema.IntervalStrokeRate,
                IntervalStrokeCount = splitSchema.IntervalStrokeCount,
                Dive = splitSchema.Dive,
                SwimId = parentSwim.Id
            };

            // Calculate percentages off PB and Goal times
            split.PerOffPBIntervalTime = await PercentageOffPBTime(splitSchema, athleteDataOwnerId, parentSwim.Event);
            split.PerOffPBStrokeRate = await PercentageOffPBTimeStrokeRate(splitSchema, athleteDataOwnerId, parentSwim.Event);
            split.PerOffGoalTime = await PercentageOffGoalTime(splitSchema, athleteDataOwnerId, parentSwim.Event);
            split.PerOffGoalStrokeRate = await PercentageOffGoalTimeStrokeRate(splitSchema, athleteDataOwnerId, parentSwim.Event);

            // Attach to context if not using swim.Splits.Add(split)
            _context.Splits.Add(split); // Optional if using parentSwim.Splits.Add(split)

            return split;
        }

        public async Task<double?> PercentageOffPBTime(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent)
        {
            // Console.WriteLine($"In Percentage Off PB Time: Event: {swimSchema.Event} Stroke: {swimSchema.Stroke}, Distance: {swimSchema.Distance}, Time: {swimSchema.Time}");

            var swimsInSameEvent = await _context.Swims
                    .Where(s => s.Event == swimEvent && s.GoalSwim == false && s.AthleteDataOwnerId == athleteDataOwnerId)
                    .Include(s => s.Splits)
                    .ToListAsync();

            if (swimsInSameEvent == null)
            {
                return null;
            }



            foreach (var swim in swimsInSameEvent)
            {
                // Console.WriteLine($"Swim: {swim.Id}, Time: {swim.Time}, Event: {swim.Event}, Distance: {swim.Distance}");
            }

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                Console.WriteLine("Returning null for PercentageOffPBTime 1");
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var targetDistance = EventHelper.GetDistance(swimEvent);

                var pbSplitFullDistance = swimsInSameEvent
                    .SelectMany(swim => swim.Splits)
                    .Where(split => split.IntervalDistance == targetDistance)
                    .OrderBy(split => split.IntervalTime)
                    .FirstOrDefault();

                // If there is a PB for the event
                if (pbSplitFullDistance != null)
                {
                    if (splitSchema.IntervalDistance == EventHelper.GetDistance(swimEvent))
                    {
                        return (splitSchema.IntervalTime - pbSplitFullDistance.IntervalTime) / pbSplitFullDistance.IntervalTime * 100;
                    }
                    else
                    {
                        Console.WriteLine($"Finding timesheet for event: {swimEvent} for Distance: {splitSchema.IntervalDistance} with Time: {splitSchema.IntervalTime}");
                        var foundTimeSheet = await _context.TimeSheets
                            .FirstOrDefaultAsync(ts => ts.Event == swimEvent) ?? throw new Exception("Time sheet not found");

                        var potentialRaceTime = InterpolationHelper.GetPotentialRaceTime(foundTimeSheet.SplitDataForTimes, splitSchema.IntervalTime, splitSchema.IntervalDistance);




                        return (potentialRaceTime - pbSplitFullDistance.IntervalTime) / pbSplitFullDistance.IntervalTime * 100;
                    }
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffPBTime 2");
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffPBTimeStrokeRate(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent)
        {
            if (splitSchema.IntervalStrokeRate == null)
            {
                Console.WriteLine("Returning null for PercentageOffPBStrokeRate 1");
                return null;        // Stroke rate does not exist thus there is no comparison
            }

            var swimsInSameEvent = await _context.Swims
                    .Where(s => s.Event == swimEvent && s.GoalSwim == false && s.AthleteDataOwnerId == athleteDataOwnerId)
                    .Include(s => s.Splits)
                    .ToListAsync();

            if (swimsInSameEvent.Count == 0 || swimsInSameEvent == null)
            {
                return null;        // Pb does not exist thus there is no comparison
            }
            else
            {
                var targetDistance = EventHelper.GetDistance(swimEvent);

                var pbSplitFullDistance = swimsInSameEvent
                    .SelectMany(swim => swim.Splits)
                    .Where(split => split.IntervalDistance == targetDistance)
                    .OrderBy(split => split.IntervalTime)
                    .FirstOrDefault();

                if (pbSplitFullDistance == null)
                {
                    Console.WriteLine("No recorded PB swim found for this event");
                    return null;        // Pb does not exist thus there is no comparison
                }

                var eventPBStrokeRate = pbSplitFullDistance.IntervalStrokeRate;

                if (eventPBStrokeRate == null)
                {
                    Console.WriteLine("PB Swim does not have a stroke rate");
                    return null;
                }

                if (eventPBStrokeRate.HasValue)
                {
                    // Console.WriteLine($"Event PB Stroke Rate: {eventPBStrokeRate}");
                    // Console.WriteLine($"Swim Schema Stroke Rate: {swimSchema.StrokeRate}");
                    // Console.WriteLine($"Returning equation ({swimSchema.StrokeRate} - {eventPBStrokeRate}) / {eventPBStrokeRate} * 100");
                    // Console.WriteLine($"Returning: {(swimSchema.StrokeRate - eventPBStrokeRate) / eventPBStrokeRate * 100}");
                    double percentage = (double)((double)(splitSchema.IntervalStrokeRate - eventPBStrokeRate) / eventPBStrokeRate * 100);
                    return percentage;
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffPBStrokeRate 2");
                    return null;
                }
            }
        }

        public async Task<double?> PercentageOffGoalTime(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent)
        {

            var goalTimes = await _context.Swims
                    .Where(s => s.Event == swimEvent && s.GoalSwim == true && s.AthleteDataOwnerId == athleteDataOwnerId)
                    .Include(s => s.Splits)
                    .ToListAsync();

            if (goalTimes.Count == 0 || goalTimes == null)
            {
                Console.WriteLine("Returning null for PercentageOffGoalTime 1");
                return null;        // Goal time does not exist thus there is no comparison
            }
            else
            {
                var targetDistance = EventHelper.GetDistance(swimEvent);

                var goalSwimSplit = goalTimes
                    .SelectMany(swim => swim.Splits)
                    .Where(split => split.IntervalDistance == splitSchema.IntervalDistance)
                    .OrderBy(split => split.IntervalTime)
                    .FirstOrDefault();

                if (goalSwimSplit != null)
                {
                    return (splitSchema.IntervalTime - goalSwimSplit.IntervalTime) / goalSwimSplit.IntervalTime * 100;
                }
                else
                {
                    var fullDistSplit = goalTimes
                    .SelectMany(swim => swim.Splits)
                    .Where(split => split.IntervalDistance == targetDistance)
                    .OrderBy(split => split.IntervalTime)
                    .FirstOrDefault();

                    var foundTimeSheet = await _context.TimeSheets
                        .FirstOrDefaultAsync(ts => ts.Event == swimEvent) ?? throw new Exception("Time sheet not found");

                    var potentialGoalSplitTime = InterpolationHelper.GetPotentialSplitTime(foundTimeSheet.SplitDataForTimes, fullDistSplit!.IntervalTime, fullDistSplit!.IntervalDistance);

                    return (potentialGoalSplitTime - fullDistSplit.IntervalTime) / fullDistSplit.IntervalTime * 100;
                }
            }
        }

        public async Task<double?> PercentageOffGoalTimeStrokeRate(CreateSplitReqDTO splitSchema, Guid athleteDataOwnerId, EventEnum swimEvent)
        {
            if (splitSchema.IntervalStrokeRate == null)
            {
                return null;        // Stroke rate is not provided thus there is no comparison
            }

            var goalSwimList = await _context.Swims
                    .Where(s => s.Event == swimEvent && s.GoalSwim == true && s.AthleteDataOwnerId == athleteDataOwnerId)
                    .ToListAsync();

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
                var targetDistance = EventHelper.GetDistance(swimEvent);

                var goalSwimSplit = goalSwimList
                    .SelectMany(swim => swim.Splits)
                    .Where(split => split.IntervalDistance == targetDistance)
                    .OrderBy(split => split.IntervalTime)
                    .FirstOrDefault();

                if (goalSwimSplit == null)
                {
                    Console.WriteLine("No recorded goal swim found for this event");
                    return null;        // Goal stroke rate does not exist thus there is no comparison
                }
                var goalStrokeRate = goalSwimSplit.IntervalStrokeRate;

                if (goalStrokeRate == null)
                {
                    Console.WriteLine("Goal Swim does not have a stroke rate");
                    return null;
                }

                if (goalStrokeRate.HasValue)
                {
                    double percentage = (double)((double)(splitSchema.IntervalStrokeRate - goalStrokeRate) / goalStrokeRate * 100);

                    return percentage;
                }
                else
                {
                    Console.WriteLine("Returning null for PercentageOffGoalStrokeRate 2");
                    return null;
                }
            }
        }

        public async Task<double?> GetPotentialRaceTime(CreateSplitReqDTO splitSchema, EventEnum swimEvent)
        {
            if (splitSchema.IntervalDistance != EventHelper.GetDistance(swimEvent))
            {
                var foundTimeSheet = await _context.TimeSheets
                    .FirstOrDefaultAsync(ts => ts.Event == swimEvent) ?? throw new Exception("Time sheet not found");

                var potentialRaceTime = InterpolationHelper.GetPotentialRaceTime(foundTimeSheet.SplitDataForTimes, splitSchema.IntervalTime, splitSchema.IntervalDistance);
                return potentialRaceTime;
            }
            else
            {
                return null;        // No potential because the distance is the same as the event distance
            }
        }
    }
}