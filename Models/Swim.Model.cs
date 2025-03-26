using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class Swim
    {
        public int Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required int Time { get; set; }

        public required Stroke Stroke { get; set; } // Stroke type

        public required int Distance { get; set; }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? perceivedExertion { get; set; }

        public required bool dive { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int SwimmerDataId { get; set; }

        public required SwimmerData SwimmerData { get; set; }

        public ICollection<Split>? Splits { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}