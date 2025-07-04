using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Domain.Helpers;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class TimeSheet
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required EventEnum Event { get; set; } // E.g: 50m Freestyle

        public List<SplitData> SplitDataForTimes { get; set; } = [];

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++



        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}