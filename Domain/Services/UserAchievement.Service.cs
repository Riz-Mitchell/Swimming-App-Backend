using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Infrastructure.Repositories;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IUserAchievementService
    {
        Task<List<GetUserAchievementResDTO>> GetUserAchievementsAsync(UserAchievementsQuery querySchema);
    }

    public class UserAchievementService : IUserAchievementService
    {
        private readonly IUserAchievementRepository _userAchievementRepository;

        public UserAchievementService(IUserAchievementRepository userAchievementRepository)
        {
            _userAchievementRepository = userAchievementRepository;
        }

        public async Task<List<GetUserAchievementResDTO>> GetUserAchievementsAsync(UserAchievementsQuery querySchema)
        {
            return await _userAchievementRepository.GetUserAchievementsAsync(querySchema);
        }
    }
}