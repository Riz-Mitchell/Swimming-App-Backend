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
        Task CheckDistanceAchievementsAsync(Guid userId, int totalDistance);
        Task CheckNumSwimsAchievementsAsync(Guid userId, int numSwims);
        Task CheckAccountAgeAchievementsAsync(Guid userId, DateTime accountCreationDate);

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

        public async Task CheckDistanceAchievementsAsync(Guid userId, int totalDistance)
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

            if (totalDistance >= marathonAchievement.TargetValue)
            {
                userProgress.Progress = marathonAchievement.TargetValue;
                userProgress.IsCompleted = true;
                userProgress.EarnedAt = DateTime.UtcNow;
            }
            else
            {
                userProgress.Progress = totalDistance;
                userProgress.IsCompleted = false;
                userProgress.EarnedAt = null;
            }

            await _context.SaveChangesAsync();
        }

        public async Task CheckNumSwimsAchievementsAsync(Guid userId, int numSwims)
        {
            await EnsureUserHasAllAchievementsAsync(userId);

            var numSwimsAchievement = await _context.Achievements
                .Where(a => a.Name == "First Swim" ||
                            a.Name == "Getting it done" ||
                            a.Name == "Busy cooking" ||
                            a.Name == "Proper chef" ||
                            a.Name == "Gotta do at least 20 bro" ||
                            a.Name == "Ashton Hall")
                .ToListAsync();

            if (numSwimsAchievement == null || numSwimsAchievement.Count == 0)
            {
                throw new Exception("Num swims achievement not found.");
            }

            var userProgresses = await _context.UserAchievements
                .Where(ua => numSwimsAchievement.Select(a => a.Id).Contains(ua.AchievementId))
                .ToListAsync();

            if (userProgresses == null || userProgresses.Count == 0)
            {
                throw new Exception("User progresses not found.");
            }

            foreach (var userProgress in userProgresses)
            {
                if (numSwims >= userProgress.Achievement.TargetValue)
                {
                    userProgress.Progress = userProgress.Achievement.TargetValue;
                    userProgress.IsCompleted = true;
                    userProgress.EarnedAt = DateTime.UtcNow;
                }
                else
                {
                    userProgress.Progress = numSwims;
                    userProgress.IsCompleted = false;
                    userProgress.EarnedAt = null;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task CheckAccountAgeAchievementsAsync(Guid userId, DateTime accountCreationDate)
        {
            await EnsureUserHasAllAchievementsAsync(userId);

            var accAgeAchievements = await _context.Achievements
                .Where(a => a.Name == "Unc status" ||
                a.Name == "Fossil")
                .ToListAsync();

            if (accAgeAchievements == null || accAgeAchievements.Count == 0)
            {
                throw new Exception("Account age achievement not found.");
            }

            var userProgresses = await _context.UserAchievements
                .Where(ua => accAgeAchievements.Select(a => a.Id).Contains(ua.AchievementId))
                .ToListAsync();

            if (userProgresses == null || userProgresses.Count == 0)
            {
                throw new Exception("User progresses not found.");
            }

            foreach (var userProgress in userProgresses)
            {
                var accAge = DateTime.UtcNow - accountCreationDate;

                var achievementName = userProgress.Achievement.Name;

                switch (achievementName)
                {
                    case "Unc status":
                        if (accAge.Days >= 365)
                        {
                            userProgress.Progress = 1;
                            userProgress.IsCompleted = true;
                            userProgress.EarnedAt = DateTime.UtcNow;
                        }
                        else
                        {
                            userProgress.Progress = 0;
                            userProgress.IsCompleted = false;
                            userProgress.EarnedAt = null;
                        }
                        break;
                    case "Fossil":
                        if (accAge.Days >= 365 * 2)
                        {
                            userProgress.Progress = 1;
                            userProgress.IsCompleted = true;
                            userProgress.EarnedAt = DateTime.UtcNow;
                        }
                        else
                        {
                            userProgress.Progress = 0;
                            userProgress.IsCompleted = false;
                            userProgress.EarnedAt = null;
                        }
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}