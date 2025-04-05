using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class Session
    {
        public int Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++\

        public int? TimeTableId { get; set; }

        public TimeTable? TimeTable { get; set; }

        public required int CoachDataCreatorId { get; set; }

        public required CoachData CoachDataCreator { get; set; }

        public ICollection<Set>? Sets { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}