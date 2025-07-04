namespace SwimmingAppBackend.Infrastructure.Models
{

    public class Friendship
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid RequesterId { get; set; }
        public required User Requester { get; set; }

        public required Guid AddresseeId { get; set; }
        public required User Addressee { get; set; }

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public bool IsConfirmed { get; set; } = false;
    }
}