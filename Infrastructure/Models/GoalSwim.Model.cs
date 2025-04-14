using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class GoalSwim
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required double Time { get; set; }

        public int? StrokeRate { get; set; }

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