using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Achievement
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int TargetValue { get; set; }

        [Range(1, 5)]
        public required int Difficulty { get; set; }

        public required UserType UserType { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public ICollection<UserAchievement> UserAchievements { get; set; } = [];

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}