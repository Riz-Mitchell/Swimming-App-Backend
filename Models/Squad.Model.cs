namespace SwimmingAppBackend.Models
{
    public class Squad
    {
        public int Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string Name { get; set; }

        public string? Description { get; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<User>? Members { get; set; }

        public int? ClubId { get; set; }

        public Club? Club { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}