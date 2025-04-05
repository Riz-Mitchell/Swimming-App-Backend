using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class Swim
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required int Time { get; set; }

        public required Stroke Stroke { get; set; } // Stroke type

        public required int Distance { get; set; }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? PerceivedExertion { get; set; }

        public required bool Dive { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid AthleteDataOwnerId { get; set; }

        public required AthleteData AthleteDataOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}