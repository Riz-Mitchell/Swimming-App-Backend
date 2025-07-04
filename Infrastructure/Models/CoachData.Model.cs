namespace SwimmingAppBackend.Infrastructure.Models
{
    public class CoachData
    {
        public Guid CoachDataId { get; set; } = Guid.NewGuid();

        // Attrubutes :
        // ------------------------------------------------

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}