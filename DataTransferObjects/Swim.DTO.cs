using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.DataTransferObjects
{
    public class GetSwimDTO
    {
        public required int Id { get; set; }

        public required int Time { get; set; }

        public required Stroke Stroke { get; set; } // Stroke type

        public required int Distance { get; set; }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? PerceivedExertion { get; set; }

        public required bool Dive { get; set; }

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int SwimmerMetaDataId { get; set; }

        // public ICollection<Split>? Splits { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }

    public class CreateSwimDTO
    {
        public required int Time { get; set; }

        public required Stroke Stroke { get; set; } // Stroke type

        public required bool Dive { get; set; }

        public required int Distance { get; set; }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? PerceivedExertion { get; set; }

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int SwimmerMetaDataId { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }

    public class UpdateSwimDTO
    {
        public int? Time { get; set; }

        public Stroke? Stroke { get; set; } // Stroke type

        public int? Distance { get; set; }

        public int? StrokeRate { get; set; }

        public int? Pace { get; set; }

        public int? PerceivedExertion { get; set; }

        public bool? Dive { get; set; }
    }
}