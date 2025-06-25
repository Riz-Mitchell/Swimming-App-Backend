using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class User
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string PhoneNumber { get; set; }

        public required string Name { get; set; }

        public required UserType UserType { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public Double? Height { get; set; } = null;

        public string? Email { get; set; } = null;

        public string? RefreshToken { get; set; } = null;

        public DateTime? RefreshTokenExpiry { get; set; } = null;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        // Friendships where this user sent the request
        public ICollection<Friendship> SentFriendRequests { get; set; } = [];

        // Friendships where this user received the request
        public ICollection<Friendship> ReceivedFriendRequests { get; set; } = [];

        public ICollection<UserAchievement> UserAchievements { get; set; } = [];

        public Guid? AthleteDataId { get; set; }
        public AthleteData? AthleteData { get; set; }

        public Guid? CoachDataId { get; set; }
        public CoachData? CoachData { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}