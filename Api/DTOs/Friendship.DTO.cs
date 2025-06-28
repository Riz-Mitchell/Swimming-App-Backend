namespace SwimmingAppBackend.Api.DTOs
{
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
}