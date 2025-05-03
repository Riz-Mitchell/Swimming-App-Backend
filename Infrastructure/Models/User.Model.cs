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

        public int? Age { get; set; }

        public string? Email { get; set; }

        public string? RefreshToken { get; set; } = null;

        public DateTime? RefreshTokenExpiry { get; set; } = null;

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required ICollection<UserAchievement> UserAchievements { get; set; } = [];

        public Guid? AthleteDataId { get; set; }
        public AthleteData? AthleteData { get; set; }

        public Guid? CoachDataId { get; set; }
        public CoachData? CoachData { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}