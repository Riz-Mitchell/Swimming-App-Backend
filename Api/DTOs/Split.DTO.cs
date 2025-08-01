using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Api.DTOs
{
    public class GetSplitResDTO
    {
        public required Guid Id { get; set; }  // Primary Key

        // Attributes:
        // ------------------------------------------------
        public Stroke Stroke { get; set; } // Stroke type for this split
        public required double IntervalTime { get; set; } // Time for this split in seconds
        public required int IntervalDistance { get; set; } // Distance for this split in meters
        public int? IntervalStrokeRate { get; set; } // Stroke rate for this split
        public int? IntervalStrokeCount { get; set; } // Stroke count for this split
        public double? PerOffPBIntervalTime { get; set; } // Percentage off personal best time for this split
        public double? PerOffPBStrokeRate { get; set; }
        public double? PerOffGoalTime { get; set; } // Percentage off goal time for this split
        public double? PerOffGoalStrokeRate { get; set; } // Percentage off goal stroke rate for this split
        public required bool Dive { get; set; } // Indicates if this split was from a dive start
    }

    public class CreateSplitReqDTO
    {
        // Attributes:
        // ------------------------------------------------
        public required Stroke Stroke { get; set; } // Stroke type for this split
        public required double IntervalTime { get; set; } // Time for this split in seconds
        public required int IntervalDistance { get; set; } // Distance for this split in meters
        public int? IntervalStrokeRate { get; set; } // Stroke rate for this split
        public int? IntervalStrokeCount { get; set; } // Stroke count for this split
        public required bool Dive { get; set; } // Indicates if this split was from a dive start
    }

    public static class SplitMapper
    {
        public static GetSplitResDTO ModelToRes(Split modelObj)
        {
            return new GetSplitResDTO
            {
                Id = modelObj.Id,
                Stroke = modelObj.Stroke,
                IntervalTime = modelObj.IntervalTime,
                IntervalDistance = modelObj.IntervalDistance,
                IntervalStrokeRate = modelObj.IntervalStrokeRate,
                IntervalStrokeCount = modelObj.IntervalStrokeCount,
                PerOffPBIntervalTime = modelObj.PerOffPBIntervalTime,
                PerOffPBStrokeRate = modelObj.PerOffPBStrokeRate,
                PerOffGoalTime = modelObj.PerOffGoalTime,
                PerOffGoalStrokeRate = modelObj.PerOffGoalStrokeRate,
                Dive = modelObj.Dive
            };
        }

        public static ICollection<GetSplitResDTO> ListModelToListRes(ICollection<Split> modelList)
        {
            ICollection<GetSplitResDTO> returnList = [];

            foreach (Split modelObj in modelList)
            {
                returnList.Add(ModelToRes(modelObj));
            }

            return returnList;
        }
    }
}