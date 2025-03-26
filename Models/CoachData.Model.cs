namespace SwimmingAppBackend.Models
{
    public class CoachData
    {
        public int CoachDataId { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}