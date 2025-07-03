using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Api.DTOs
{
    public class GetFriendshipQuery
    {
        public Guid UserId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetFriendshipResDTO
    {
        public Guid Id { get; set; }

        public required Guid RequesterId { get; set; }
        public required Guid AddresseeId { get; set; }
        public required bool IsConfirmed { get; set; }
    }

    public class CreateFriendshipReqDTO
    {
        public required Guid AddresseeId { get; set; }
    }

    public class UpdateFriendshipReqDTO
    {
        public required Guid FriendshipId { get; set; }
        public required bool IsConfirmed { get; set; }
    }

    public static class FriendshipMapper
    {
        public static GetFriendshipResDTO ModelToRes(Friendship modelObj)
        {
            return new GetFriendshipResDTO
            {
                Id = modelObj.Id,
                RequesterId = modelObj.RequesterId,
                AddresseeId = modelObj.AddresseeId,
                IsConfirmed = modelObj.IsConfirmed
            };
        }

        public static List<GetFriendshipResDTO> ListModelToListRes(List<Friendship> modelList)
        {
            List<GetFriendshipResDTO> returnList = [];

            foreach (Friendship modelObj in modelList)
            {
                returnList.Add(ModelToRes(modelObj));
            }

            return returnList;
        }
    }
}