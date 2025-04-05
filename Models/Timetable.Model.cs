using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class TimeTable
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid SquadId { get; set; }

        public required Squad Squad { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}