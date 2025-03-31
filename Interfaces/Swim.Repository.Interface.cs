using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Interfaces
{
    public interface ISwimRepository
    {
        Task<List<Swim>> GetAllAsync();

        Task<Swim?> GetByIdAsync(int id);

        Task CreateAsync(Swim swim);

        Task<Swim?> UpdateAsync(int id, UpdateSwimDTO updateSwimDTO);

        Task DeleteAsync(Swim swim);
    }
}