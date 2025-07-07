using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class UserSubscription
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Primary Key

        public required Platform Platform { get; set; } // e.g., "Apple", "Google", "Trial"
        public required Product ProductId { get; set; } // e.g., "com.myapp.pro_monthly"
        public string? OriginalTransactionId { get; set; } // Apple-specific
        public string? PurchaseToken { get; set; } // Google-specific
        public string? Receipt { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys / Relations:

        public required Guid UserId { get; set; }
        public required User User { get; set; }
    }
}