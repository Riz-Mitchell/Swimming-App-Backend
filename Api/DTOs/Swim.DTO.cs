
using SwimmingAppBackend.Enum;
namespace SwimmingAppBackend.Api.DTOs
{
    public class GetSwimsQuery
    {
        public Guid? UserId { get; set; }
        public EventEnum? Event { get; set; }
        public bool? OnlyPersonalBest { get; set; } = false;
        public bool? OnlyGoalSwim { get; set; } = false;
        public bool? OnlyDive { get; set; } = false;

        public TimePeriod? TimePeriod { get; set; } = Enum.TimePeriod.Week;


        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetSwimResDTO
    {
        public required Guid Id { get; set; }  // Primary Key
        public required EventEnum Event { get; set; } // Event type
        public required double Time { get; set; }
        public required Stroke Stroke { get; set; } // Stroke type
        public required int Distance { get; set; }
        public double? PercentageOffPBTime { get; set; }
        public double? PercentageOffPBStrokeRate { get; set; }
        public double? PercentageOffGoalTime { get; set; }
        public double? PercentageOffGoalStrokeRate { get; set; }
        public double? PotentialRaceTime { get; set; }
        public int? StrokeRate { get; set; }
        public int? StrokeCount { get; set; }
        public int? PerceivedExertion { get; set; }
        public required bool Dive { get; set; }
        public required bool GoalSwim { get; set; }
        public required DateTime RecordedAt { get; set; }
    }

    public class CreateSwimReqDTO
    {
        public required EventEnum Event { get; set; } // Event type
        public required double Time { get; set; }
        public required Stroke Stroke { get; set; } // Stroke type
        public required int Distance { get; set; }
        public int? StrokeRate { get; set; }
        public int? StrokeCount { get; set; }
        public int? PerceivedExertion { get; set; }
        public bool? Dive { get; set; }
        public bool? GoalSwim { get; set; }
    }


    public class UpdateSwimReqDTO
    {
        public EventEnum? Event { get; set; } // Event type
        public double? Time { get; set; }
        public Stroke? Stroke { get; set; } // Stroke type
        public int? Distance { get; set; }
        public int? StrokeRate { get; set; }
        public int? StrokeCount { get; set; }
        public int? PerceivedExertion { get; set; }
        public bool? Dive { get; set; }
        public bool? GoalSwim { get; set; }
    }
}