using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Api.DTOs
{
    public enum UserAchievementOrderBy
    {
        Progress,
        Difficulty,
    }

    public class UserAchievementsQuery
    {
        public Guid? UserId { get; set; }
        public UserAchievementOrderBy OrderBy { get; set; } = UserAchievementOrderBy.Progress;
        public bool IsDescending { get; set; } = false;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetUserAchievementResDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int TargetValue { get; set; }
        public required int Progress { get; set; }
        public required bool IsCompleted { get; set; }
        public required DateTime? EarnedAt { get; set; }
        public required int Difficulty { get; set; }
    }
}