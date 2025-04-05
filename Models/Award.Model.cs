using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class Award
    {
        public int Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------



        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required int CoachDataOwnerId { get; set; }

        public required User CoachDataOwner { get; set; }

        public ICollection<AthleteData>? Recipients { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}