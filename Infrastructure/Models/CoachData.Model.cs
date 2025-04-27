namespace SwimmingAppBackend.Infrastructure.Models
{
    public class CoachData
    {
        public Guid CoachDataId { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public ICollection<Achievement>? Achievements { get; set; }

        public ICollection<Award>? Awards { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}