using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class AthleteData
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public string? MainStroke { get; set; }

        public int? MainDistance { get; set; }

        public string? GoalTime { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        public ICollection<Swim>? Swims { get; set; }

        public ICollection<GoalSwim>? GoalSwims { get; set; }

        public ICollection<Achievement>? Achievements { get; set; }

        public ICollection<Award>? Awards { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}