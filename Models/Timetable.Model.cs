using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class TimeTable
    {
        public int Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int SquadId { get; set; }

        public required Squad Squad { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}