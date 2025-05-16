using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Enum;
using System.Globalization;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface IUserAchievementRepository
    {
        Task<List<GetUserAchievementResDTO>> GetUserAchievementsAsync(UserAchievementsQuery querySchema);
        Task EnsureUserHasAllAchievementsAsync(Guid userId);
        Task IncramentDistanceAchievementsAsync(Guid userId, int distance);
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
            await _context.Database.EnsureCreatedAsync();

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

        public async Task EnsureUserHasAllAchievementsAsync(Guid userId)
        {
            // Get all achievement IDs
            var allAchievementIds = await _context.Achievements
                .Select(a => a.Id)
                .ToListAsync();

            // Get achievement IDs that the user already has
            var userAchievementIds = await _context.UserAchievements
                .Where(ua => ua.UserId == userId)
                .Select(ua => ua.AchievementId)
                .ToListAsync();

            // Identify missing achievement IDs
            var missingAchievementIds = allAchievementIds.Except(userAchievementIds).ToList();

            if (missingAchievementIds.Count > 0)
            {
                // Create and add missing user achievements
                var newUserAchievements = missingAchievementIds.Select(id => new UserAchievement
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    AchievementId = id,
                    Progress = 0,
                    IsCompleted = false,
                    EarnedAt = null
                });

                _context.UserAchievements.AddRange(newUserAchievements);
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncramentDistanceAchievementsAsync(Guid userId, int distance)
        {
            await EnsureUserHasAllAchievementsAsync(userId);

            var marathonAchievement = await _context.Achievements
                .FirstOrDefaultAsync(a => a.Name == "Marathon Swimmer");

            if (marathonAchievement == null)
            {
                throw new Exception("Marathon Swimmer achievement not found.");
            }

            var userProgress = await _context.UserAchievements
                .FirstOrDefaultAsync(ua => ua.AchievementId == marathonAchievement.Id);

            if (userProgress == null)
            {
                throw new Exception("User progress not found.");
            }

            userProgress.Progress += distance;
            await _context.SaveChangesAsync();
        }
    }
}