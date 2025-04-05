using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Models
{
    public class SetItem
    {
        public int Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int SetId { get; set; }

        public required Set Set { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}