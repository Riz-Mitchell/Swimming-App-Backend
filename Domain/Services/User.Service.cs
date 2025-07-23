using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Repositories;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IUserService
    {
        Task<List<GetUserResDTO>> GetUsersByQuery(GetUsersQuery queryParams);
        Task<GetUserResDTO?> GetUserById(Guid id);
        Task<GetUserResDTO?> CreateUser(CreateUserReqDTO userSchema);
        Task<GetUserResDTO?> UpdateUser(Guid id, UpdateUserReqDTO userUpdates);
        Task DeleteUser(Guid id);
        Task<GetUserResDTO?> GetUserByPhoneNumber(string phoneNumber);
        Task SaveRefreshTokenAsync(Guid id, string refreshToken, DateTime dateTime);
        Task<GetUserResDTO?> FindUserAndRefreshToken(Guid id, string refreshToken);
        Task InvalidateRefreshToken(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserResDTO>> GetUsersByQuery(GetUsersQuery queryParams)
        {
            var users = await _userRepository.GetUsersAsync(queryParams);

            return users;
        }
        public async Task<GetUserResDTO?> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return user;
        }
        public async Task<GetUserResDTO?> CreateUser(CreateUserReqDTO userSchema)
        {
            return await _userRepository.CreateUserAsync(userSchema);
        }
        public async Task<GetUserResDTO?> UpdateUser(Guid id, UpdateUserReqDTO userUpdates)
        {
            return await _userRepository.UpdateUserAsync(id, userUpdates);
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<GetUserResDTO?> GetUserByPhoneNumber(string phoneNumber)
        {
            var getUserResDTO = await _userRepository.GetUserByAttribute(phoneNumber);

            return getUserResDTO;
        }

        public async Task SaveRefreshTokenAsync(Guid id, string refreshToken, DateTime dateTime)
        {
            await _userRepository.UpdateUserRefreshTokenAsync(id, refreshToken, dateTime);
        }

        public async Task<GetUserResDTO?> FindUserAndRefreshToken(Guid id, string refreshToken)
        {
            var getUserResDTO = await _userRepository.GetUserAndCheckRefreshToken(id, refreshToken);
            if (getUserResDTO == null)
            {
                return null;
            }
            else
            {
                return getUserResDTO;
            }
        }

        public async Task InvalidateRefreshToken(Guid id)
        {
            await _userRepository.InvalidateRefreshToken(id);
        }
    }
}