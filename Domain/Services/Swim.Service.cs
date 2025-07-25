using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Repositories;
using System.Runtime.InteropServices;

namespace SwimmingAppBackend.Domain.Services
{
    public interface ISwimService
    {
        Task<List<GetSwimResDTO>?> GetSwimsAsync(GetSwimsQuery query);
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid swimId);
        Task<GetSwimResDTO?> CreateSwimAsync(Guid userId, CreateSwimReqDTO createSchema);
        Task<GetSwimResDTO?> UpdateSwimAsync(Guid userId, Guid swimId, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid swimId, Guid userId);
    }

    public class SwimService : ISwimService
    {
        private readonly ISwimRepository _swimRepository;
        private readonly IAthleteDataRepository _athleteDataRepository;

        public SwimService(ISwimRepository swimRepository, IAthleteDataRepository athleteDataRepository)
        {
            _swimRepository = swimRepository;
            _athleteDataRepository = athleteDataRepository;
        }

        public Task<List<GetSwimResDTO>?> GetSwimsAsync(GetSwimsQuery query)
        {
            return _swimRepository.GetSwimsAsync(query);
        }

        public async Task<GetSwimResDTO?> GetSwimByIdAsync(Guid swimId)
        {
            return await _swimRepository.GetSwimByIdAsync(swimId);
        }

        public async Task<GetSwimResDTO?> CreateSwimAsync(Guid userId, CreateSwimReqDTO createSchema)
        {
            var athleteDataOwnerId = await _athleteDataRepository.GetAthleteDataOwnerIdByUserIdAsync(userId);
            // Console.WriteLine($"AthleteDataOwnerId: {athleteDataOwnerId}");

            if (athleteDataOwnerId == null)
            {
                Console.WriteLine($"AthleteDataOwnerId is null for UserId: {userId}");
                return null;
            }

            var newSwimResDTO = await _swimRepository.CreateSwimAsync(createSchema, (Guid)athleteDataOwnerId);

            return newSwimResDTO;
        }

        public async Task<GetSwimResDTO?> UpdateSwimAsync(Guid userId, Guid swimId, UpdateSwimReqDTO updateSchema)
        {

            var updatedSwimResDTO = await _swimRepository.UpdateSwimAsync(swimId, userId, updateSchema);

            return updatedSwimResDTO;
        }

        public async Task DeleteSwimAsync(Guid swimId, Guid userId)
        {
            await _swimRepository.DeleteSwimAsync(swimId, userId);
        }
    }
}