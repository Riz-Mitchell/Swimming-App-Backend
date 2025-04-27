namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Squad
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string Name { get; set; }

        public string? Description { get; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<User>? Members { get; set; }

        public ICollection<Timetable>? Timetables { get; set; }

        public Guid? ClubId { get; set; }

        public Club? Club { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}