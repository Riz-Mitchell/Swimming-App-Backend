using System.ComponentModel.DataAnnotations;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class Event
    {
        public Guid Id { get; set; }  // Primary Key

        // Attrubutes :
        // ------------------------------------------------



        public required Stroke Stroke { get; set; } // Stroke type

        public required int Distance { get; set; }

        public required EventEnum EventEnum { get; set; } // Event type

        // ------------------------------------------------

        // Foreign Keys / Relations:
        // ++++++++++++++++++++++++++++++++++++++++++++++++

        public required Guid TimeSheetId { get; set; }

        public required TimeSheet TimeSheet { get; set; }

        // ++++++++++++++++++++++++++++++++++++++++++++++++
    }
}