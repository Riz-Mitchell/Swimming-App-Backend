namespace SwimmingAppBackend.Infrastructure.Models
{
    public class UserAchievement
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key

        // Attributes :
        // ------------------------------------------------

        public int Progress { get; set; } = 0;

        public bool IsCompleted { get; set; } = false;

        public DateTime? EarnedAt { get; set; } = null;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public required Guid AchievementId { get; set; }
        public Achievement Achievement { get; set; } = null!;

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}