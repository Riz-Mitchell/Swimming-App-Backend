using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Api.DTOs
{
    public class GetSplitResDTO
    {
        public Guid Id { get; set; }  // Primary Key

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
        public DateTime RecordedAt { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid SwimId { get; set; }
    }

    public class CreateSplitReqDTO
    {

        public Guid Id { get; set; }  // Primary Key

        // Attributes:
        // ------------------------------------------------
        public required Stroke Stroke { get; set; } // Stroke type for this split
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
}