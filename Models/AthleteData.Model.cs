using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class AthleteData
    {
        public int Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public string? MainStroke { get; set; }

        public int? MainDistance { get; set; }

        public string? GoalTime { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int UserOwnerId { get; set; }

        public required User UserOwner { get; set; }

        public ICollection<Swim>? Swims { get; set; }

        public ICollection<Achievement>? Achievements { get; set; }

        public ICollection<Award>? Awards { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}