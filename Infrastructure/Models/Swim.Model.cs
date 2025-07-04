using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Swim
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key

        // Attrubutes :
        // ------------------------------------------------
        public required EventEnum Event { get; set; } // E.g: 50m Freestyle
        public int? PerceivedExertion { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
        public bool GoalSwim { get; set; } = false;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<Split> Splits { get; set; } = [];

        public required Guid AthleteDataOwnerId { get; set; }

        public required AthleteData AthleteDataOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}