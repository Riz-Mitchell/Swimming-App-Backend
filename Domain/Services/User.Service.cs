using SwimmingAppBackend.Api.DTOs;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IUserService
    {
        public Task<List<GetUserResDTO>> GetUsersByQuery(GetUsersQuery queryParams);
        public Task<GetUserResDTO?> GetUserById(Guid id);
        public Task<GetUserResDTO> CreateUser(CreateUserReqDTO userSchema);
        public Task<GetUserResDTO> UpdateUser(Guid id, UpdateUserReqDTO userUpdates);
        public Task DeleteUser(Guid id);
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
            var users = await _userRepository.GetUsersByQueryAsync(queryParams);

            return users;
        }
        public async Task<GetUserResDTO?> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return user;
        }
        public async Task<GetUserResDTO> CreateUser(CreateUserReqDTO userSchema)
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
    }
}