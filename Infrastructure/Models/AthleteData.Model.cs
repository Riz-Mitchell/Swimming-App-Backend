using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class AthleteData
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Attrubutes :
        // ------------------------------------------------

        public Guid? ExternalSourceUserId = null;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        public ICollection<Swim> Swims { get; set; } = [];

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}