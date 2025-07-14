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

        public required PoolType PoolType { get; set; } = PoolType.LongCourseMeters;

        // External deeds
        public bool IsExternal { get; set; } = false; // Has it come from another api (Swim can be tracked as a race) from an actual event
        public Guid? ExternalId { get; set; } = null;
        public ExternalSource? ExternalSource { get; set; } = null;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<Split> Splits { get; set; } = [];

        public required Guid AthleteDataOwnerId { get; set; }

        public AthleteData AthleteDataOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}