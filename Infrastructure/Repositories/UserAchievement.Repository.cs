using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface IUserAchievementRepository
    {
        Task<List<GetUserAchievementResDTO>> GetUserAchievementsAsync(UserAchievementsQuery querySchema);
    }

    public class UserAchievementsRepository : IUserAchievementRepository
    {

        private readonly SwimmingAppDBContext _context;

        public UserAchievementsRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetUserAchievementResDTO>> GetUserAchievementsAsync(UserAchievementsQuery querySchema)
        {
            // Step 1: Ensure all achievements exist for the user
            var allAchievements = await _context.Achievements.ToListAsync();

            var existingAchievementIds = await _context.UserAchievements
                .Where(ua => ua.UserId == querySchema.UserId)
                .Select(ua => ua.AchievementId)
                .ToListAsync();

            var missingAchievements = allAchievements
                .Where(a => !existingAchievementIds.Contains(a.Id))
                .ToList();

            if (missingAchievements.Any())
            {
                var newUserAchievements = missingAchievements.Select(a => new UserAchievement
                {
                    Id = Guid.NewGuid(),
                    UserId = (Guid)querySchema.UserId!,
                    AchievementId = a.Id,
                    Progress = 0,
                    IsCompleted = false,
                    EarnedAt = null
                }).ToList();

                _context.UserAchievements.AddRange(newUserAchievements);
                await _context.SaveChangesAsync(); // Ensure they're written before querying below
            }

            // Step 2: Proceed with normal retrieval
            IQueryable<UserAchievement> query = _context.UserAchievements
                .Where(ua => ua.UserId == querySchema.UserId)
                .Include(ua => ua.Achievement);

            switch (querySchema.OrderBy)
            {
                case UserAchievementOrderBy.Progress:
                    query = querySchema.IsDescending
                        ? query.OrderByDescending(ua => ua.Progress)
                        : query.OrderBy(ua => ua.Progress);
                    break;
                case UserAchievementOrderBy.Difficulty:
                    query = querySchema.IsDescending
                        ? query.OrderByDescending(ua => ua.Achievement.Difficulty)
                        : query.OrderBy(ua => ua.Achievement.Difficulty);
                    break;
            }

            query = query
                .Skip((querySchema.Page - 1) * querySchema.PageSize)
                .Take(querySchema.PageSize);

            var userAchievements = await query.ToListAsync();

            return userAchievements.Select(ua => new GetUserAchievementResDTO
            {
                Id = ua.Id,
                Name = ua.Achievement.Name,
                Description = ua.Achievement.Description,
                TargetValue = ua.Achievement.TargetValue,
                Progress = ua.Progress,
                IsCompleted = ua.IsCompleted,
                EarnedAt = ua.EarnedAt,
                Difficulty = ua.Achievement.Difficulty
            }).ToList();
        }

    }
}