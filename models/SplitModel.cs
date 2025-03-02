using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingAppBackend.Models
{
    public class Split
    {
        public int Id { get; set; }  // Primary Key

        // Foreign Key to Swim (One Swim can have many Splits)
        public int SwimId { get; set; }

        // Properties for Split
        [Range(0, 2400)] // Time in seconds (max 40 minutes)
        public int? Time { get; set; }

        [Range(20, 100)] // Stroke rate
        public int? StrokeRate { get; set; }

        [Required]
        public string? Stroke { get; set; } // Stroke type

        [Range(5, 1500, ErrorMessage = "Distance must be a multiple of 5")]
        public int? Distance { get; set; } // Distance covered in this split (intervals of 5)

        public int? Pace { get; set; } // 50, 100, 200, 400, 800, 1500

        [Range(1, 10)] // Perceived exertion (scale of 1-10)
        public int? PerceivedExertion { get; set; }

        public bool? Dive { get; set; } // Whether the split had a dive

        // Navigation property to relate Split to Swim
        public required Swim Swim { get; set; }  // Each Split relates to a Swim
    }
}