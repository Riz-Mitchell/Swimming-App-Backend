namespace SwimmingAppBackend.Models
{
    public class CoachMetaData
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