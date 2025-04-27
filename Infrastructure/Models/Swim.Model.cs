using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Swim
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required double Time { get; set; }
        public required Stroke Stroke { get; set; } // Stroke type
        public required int Distance { get; set; }
        public double? PercentageOffPBTime { get; set; }
        public double? PercentageOffPBStrokeRate { get; set; }
        public double? PercentageOffGoalTime { get; set; }
        public double? PercentageOffGoalStrokeRate { get; set; }
        public int? StrokeRate { get; set; }
        public int? StrokeCount { get; set; }
        public int? Pace { get; set; }
        public int? PerceivedExertion { get; set; }
        public required bool Dive { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
        public bool GoalSwim { get; set; } = false;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid EventId { get; set; }

        public required Event Event { get; set; }

        public required Guid AthleteDataOwnerId { get; set; }

        public required AthleteData AthleteDataOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}