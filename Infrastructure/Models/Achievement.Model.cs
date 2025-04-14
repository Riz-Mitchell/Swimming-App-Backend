using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Achievement
    {
        public Guid Id { get; set; }

        // Attrubutes :
        // ------------------------------------------------

        public required string Name { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++



        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}