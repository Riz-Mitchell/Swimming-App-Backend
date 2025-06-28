using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Repositories;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IFriendshipService
    {
        Task<GetFriendshipResDTO> SendFriendRequestAsync(Guid requesterId, Guid addresseeId);
        Task<GetFriendshipResDTO?> GetFriendshipBetweenUsersAsync(Guid user1Id, Guid user2Id);
        Task<bool> RemoveFriendshipAsync(Guid friendshipId, Guid userId);
        Task<bool> AcceptFriendRequestAsync(Guid addresseeId, Guid friendshipId);
        Task GetAllForUserAsync(Guid userId);
    }

    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task<GetFriendshipResDTO> SendFriendRequestAsync(Guid requesterId, Guid addresseeId)
        {
            return await _friendshipRepository.AddAsync(requesterId, addresseeId);
        }

        public async Task<GetFriendshipResDTO?> GetFriendshipBetweenUsersAsync(Guid user1Id, Guid user2Id)
        {
            return await _friendshipRepository.FindByUsersAsync(user1Id, user2Id);
        }

        public async Task<bool> RemoveFriendshipAsync(Guid friendshipId, Guid userId)
        {
            GetFriendshipResDTO? foundFriendship = await _friendshipRepository.FindByUsersAsync(friendshipId, userId);

            if (foundFriendship == null)
            {
                return false; // Friendship not found
            }

            if (foundFriendship.RequesterId == userId || foundFriendship.AddresseeId == userId)
            {
                // User is part of the friendship, proceed to delete
                await _friendshipRepository.DeleteAsync(friendshipId);

                return true;
            }
            else
            {
                return false; // User is not part of the friendship
            }
        }

        public async Task<bool> AcceptFriendRequestAsync(Guid addresseeId, Guid friendshipId)
        {
            var friendship = await _friendshipRepository.FindByUsersAsync(addresseeId, friendshipId);
            if (friendship == null)
            {
                return false;
            }

            // Assuming the repository has a method to update the friendship status
            UpdateFriendshipReqDTO updateReq = new UpdateFriendshipReqDTO
            {
                FriendshipId = friendship.Id,
                IsConfirmed = true
            };

            await _friendshipRepository.UpdateAsync(updateReq);
            return true;
        }
    }
}