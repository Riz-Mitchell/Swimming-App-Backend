using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Swim
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public bool GoalTime { get; set; } = false;

        public required double Time { get; set; }

        public required Stroke Stroke { get; set; } // Stroke type

        public required int Distance { get; set; }

        public double? PercentageOffPB
        {
            get
            {
                if (AthleteDataOwner?.Swims == null || AthleteDataOwner.Swims.Count == 0)
                {
                    return null;
                }

                var swimsInSameEvent = AthleteDataOwner.Swims
                    .Where(s => s.EventId == this.EventId)
                    .ToList();

                var pbTime = swimsInSameEvent.Min(s => s.Time);

                return ((this.Time - pbTime) / pbTime) * 100;
            }
        }

        public double? PercentageOffGoalTime
        {
            get
            {
                if (AthleteDataOwner?.GoalSwims == null || AthleteDataOwner.GoalSwims.Count == 0)
                {
                    return null;
                }

                var goalTimes = AthleteDataOwner.GoalSwims
                    .Where(s =>
                        s.EventId == this.EventId
                    )
                    .ToList();

                var goalTime = goalTimes.Min(s => s.Time);

                return ((this.Time - goalTime) / goalTime) * 100;
            }
        }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? PerceivedExertion { get; set; }

        public required bool Dive { get; set; }

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

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