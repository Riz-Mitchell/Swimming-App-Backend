using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Repositories;

namespace SwimmingAppBackend.Domain.Services
{
    public interface ISwimService
    {
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid swimId);
        Task<GetSwimResDTO?> CreateSwimAsync(Guid userId, CreateSwimReqDTO createSchema);
        // Task<GetSwimResDTO?> UpdateSwimAsync(Guid userId, Guid swimId, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid swimId, Guid userId);
    }

    public class SwimService : ISwimService
    {
        private readonly ISwimRepository _swimRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAthleteDataRepository _athleteDataRepository;

        public SwimService(ISwimRepository swimRepository, IEventRepository eventRepository, IAthleteDataRepository athleteDataRepository)
        {
            _swimRepository = swimRepository;
            _athleteDataRepository = athleteDataRepository;
            _eventRepository = eventRepository;
        }

        public async Task<GetSwimResDTO?> GetSwimByIdAsync(Guid swimId)
        {
            return await _swimRepository.GetSwimByIdAsync(swimId);
        }

        public async Task<GetSwimResDTO?> CreateSwimAsync(Guid userId, CreateSwimReqDTO createSchema)
        {
            var athleteDataOwnerId = await _athleteDataRepository.GetAthleteDataOwnerIdByUserIdAsync(userId);

            if (athleteDataOwnerId == null)
            {
                return null;
            }

            var eventId = await _eventRepository.GetEventIdByEventEnumAsync(createSchema.Event);

            if (eventId == null)
            {
                return null;
            }

            var newSwimResDTO = await _swimRepository.CreateSwimAsync(createSchema, (Guid)athleteDataOwnerId, (Guid)eventId);

            return newSwimResDTO;
        }

        // public Task<GetSwimResDTO?> UpdateSwimAsync(Guid userId, Guid swimId, UpdateSwimReqDTO updateSchema)
        // {


        //     var updatedSwimResDTO = _swimRepository.UpdateSwimAsync(userId, swimId, updateSchema);
        // }

        public async Task DeleteSwimAsync(Guid swimId, Guid userId)
        {
            await _swimRepository.DeleteSwimAsync(swimId, userId);
        }
    }
}