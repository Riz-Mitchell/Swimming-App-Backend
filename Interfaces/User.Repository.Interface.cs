using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task CreateAsync(User user);

        Task<User?> UpdateAsync(int id, UpdateUserDTO updateUserDTO);

        Task DeleteAsync(User user);
    }
}