using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Award
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid CoachDataOwnerId { get; set; }

        public required CoachData CoachDataOwner { get; set; }

        public ICollection<AthleteData>? Recipients { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}