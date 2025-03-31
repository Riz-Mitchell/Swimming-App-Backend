using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class User
    {
        public int Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string PhoneNumber { get; set; }

        public required string Name { get; set; }

        public required UserType UserType { get; set; }

        public int? Age { get; set; }

        public string? Email { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public int? SquadId { get; set; }
        public Squad? Squad { get; set; }

        public int? SwimmerMetaDataId { get; set; }
        public SwimmerMetaData? SwimmerMetaData { get; set; }

        public int? CoachMetaDataId { get; set; }
        public CoachMetaData? CoachMetaData { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}