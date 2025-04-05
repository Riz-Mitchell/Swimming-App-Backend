using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class Session
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++\

        public Guid? TimeTableId { get; set; }

        public TimeTable? TimeTable { get; set; }

        public required Guid CoachDataOwnerId { get; set; }

        public required CoachData CoachDataOwner { get; set; }

        public ICollection<Set>? Sets { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}