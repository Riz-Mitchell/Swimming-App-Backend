using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class TimeSheet
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required int Interval;       // E.g: Time at 5m intervals

        public required int StartInterval;  // E.g: The distance at which intervals start

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required ICollection<TimeSheetItem> TimeSheetItems { get; set; }

        public required Guid EventId { get; set; }

        public required Event Event { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}