using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class TimeSheetItem
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------

        public required double Time { get; set; }

        public required double CurrentInterval { get; set; }

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid TimeSheetId { get; set; }

        public required TimeSheet TimeSheet { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}