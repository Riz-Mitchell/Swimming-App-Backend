using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.DataTransferObjects
{
    public class GetSwimmerMetaDataDTO
    {
        public int Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public string? MainStroke { get; set; }

        public int? MainDistance { get; set; }

        public string? GoalTime { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int UserOwnerId { get; set; }

        public ICollection<Swim>? Swims { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }

    public class UpdateSwimmerMetaDataDTO
    {
        public string? MainStroke { get; set; }

        public int? MainDistance { get; set; }

        public string? GoalTime { get; set; }
    }
}