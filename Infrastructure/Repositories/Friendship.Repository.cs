using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface IFriendshipRepository
    {
        Task<GetFriendshipResDTO?> FindByIdAsync(Guid friendshipId);
        Task<GetFriendshipResDTO?> FindByUsersAsync(Guid user1, Guid user2);
        Task<GetFriendshipResDTO> AddAsync(Guid requesterId, Guid addresseeId);
        Task<bool> DeleteAsync(Guid friendshipId);
        Task<bool> UpdateAsync(UpdateFriendshipReqDTO updateReq);
        Task<List<GetFriendshipResDTO>> GetAllForUserAsync(GetFriendshipQuery userId);
    }

    public class FriendshipRepository : IFriendshipRepository
    {
        SwimmingAppDBContext _context;

        public FriendshipRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<GetFriendshipResDTO?> FindByIdAsync(Guid friendshipId)
        {
            var friendship = await _context.Friendships
                .FirstOrDefaultAsync(f => f.Id == friendshipId);

            if (friendship == null)
            {
                return null; // No friendship found
            }

            return FriendshipMapper.ModelToRes(friendship);
        }

        public async Task<GetFriendshipResDTO> AddAsync(Guid requesterId, Guid addresseeId)
        {
            User? foundRequester = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == requesterId);

            if (foundRequester == null)
            {
                throw new ArgumentException("Requester not found");
            }

            User? foundAddressee = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == addresseeId);

            if (foundAddressee == null)
            {
                throw new ArgumentException("Addressee not found");
            }

            var newFriendship = new Friendship
            {
                Id = Guid.NewGuid(),
                RequesterId = requesterId,
                Requester = foundRequester,
                AddresseeId = addresseeId,
                Addressee = foundAddressee,
                RequestedAt = DateTime.UtcNow,
                IsConfirmed = false
            };
            await _context.SaveChangesAsync();

            return FriendshipMapper.ModelToRes(newFriendship);
        }

        public async Task<bool> DeleteAsync(Guid friendshipId)
        {
            var friendship = await _context.Friendships
                .FirstOrDefaultAsync(f => f.Id == friendshipId);

            if (friendship == null)
            {
                throw new ArgumentException("Friendship not found");
            }

            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GetFriendshipResDTO?> FindByUsersAsync(Guid user1, Guid user2)
        {
            var friendship = await _context.Friendships
                .FirstOrDefaultAsync(f =>
                    (f.RequesterId == user1 && f.AddresseeId == user2) ||
                    (f.RequesterId == user2 && f.AddresseeId == user1));

            if (friendship == null)
            {
                return null; // No friendship found
            }

            return FriendshipMapper.ModelToRes(friendship);
        }

        public async Task<bool> UpdateAsync(UpdateFriendshipReqDTO updateReq)
        {
            var foundFriendship = await _context.Friendships
                .FirstOrDefaultAsync(f => f.Id == updateReq.FriendshipId);

            if (foundFriendship == null)
            {
                throw new ArgumentException("Friendship not found");
            }

            foundFriendship.IsConfirmed = updateReq.IsConfirmed;
            _context.Friendships.Update(foundFriendship);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetFriendshipResDTO>> GetAllForUserAsync(GetFriendshipQuery query)
        {
            var friendshipsQuery = _context.Friendships
                .Where(f => f.RequesterId == query.UserId || f.AddresseeId == query.UserId);

            if (query.Page > 0 && query.PageSize > 0)
            {
                friendshipsQuery = friendshipsQuery
                    .Skip((query.Page - 1) * query.PageSize)
                    .Take(query.PageSize);
            }

            List<Friendship> friendshipListAsModel = await friendshipsQuery.ToListAsync();

            return FriendshipMapper.ListModelToListRes(friendshipListAsModel);
        }
    }
}