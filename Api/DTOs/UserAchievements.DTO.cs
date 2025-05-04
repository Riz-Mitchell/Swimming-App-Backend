namespace SwimmingAppBackend.Api.DTOs
{
    public enum UserAchievementOrderBy
    {
        ProgressAsc,
        ProgressDesc,
        DifficultyAsc,
        DifficultyDesc,
    }

    public class UserAchievementsQuery
    {
        public Guid? UserId { get; set; }
        public UserAchievementOrderBy OrderBy { get; set; } = UserAchievementOrderBy.ProgressAsc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}