namespace SwimmingAppBackend.Models
{
    public class Club
    {
        public Guid ClubId { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string Name { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<Squad>? Squads { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}