using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingAppBackend.Models
{
    public class Split
    {
        public int Id { get; set; }  // Primary Key

        // One Split has One Swim (1 -> 1)
        public int swimId { get; set; }
        public required Swim swim { get; set; }  // Each Split relates to a Swim

        // Properties for Split
        [Range(0, 2400)] // Time in seconds (max 40 minutes)
        public int? time { get; set; }

        [Range(20, 100)] // Stroke rate
        public int? strokeRate { get; set; }

        [Required]
        public string? stroke { get; set; } // Stroke type

        [Range(5, 1500, ErrorMessage = "Distance must be a multiple of 5")]
        public int? distance { get; set; } // Distance covered in this split (intervals of 5)

        public int? pace { get; set; } // 50, 100, 200, 400, 800, 1500

        [Range(1, 10)] // Perceived exertion (scale of 1-10)
        public int? perceivedExertion { get; set; }

        public bool? dive { get; set; } // Whether the split had a dive
    }
}