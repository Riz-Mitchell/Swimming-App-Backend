using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Interfaces
{
    public interface ISwimmerMetaDataRepository
    {
        Task<SwimmerMetaData?> GetByIdAsync(int id);

        Task<SwimmerMetaData?> UpdateAsync(int id, UpdateSwimmerMetaDataDTO updateSwimmerMetaDataDTO);
    }
}