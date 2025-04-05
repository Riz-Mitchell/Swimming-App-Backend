using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class Set
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid SessionId { get; set; }

        public required Session Session { get; set; }

        public ICollection<SetItem>? SetItems { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}