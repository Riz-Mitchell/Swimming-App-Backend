using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class Swim
    {
        public int id { get; set; }  // Primary Key

        // One Swim has One Swimmer (1 -> 1)
        public int swimmerProfileId { get; set; }
        public SwimmerProfile swimmerProfile { get; set; }

        // Properties for Swim
        [Required]
        [AllowedStrokeAttribute(ErrorMessage = "Please select Freestyle, Backstroke, Breaststroke, Butterfly or IM")]
        public string? stroke { get; set; } // Stroke type (Freestyle, Backstroke, etc.)

        [Required]
        [MultipleOfFiveAttribute(ErrorMessage = "Distance must be a multiple of 5")]
        public int? distance { get; set; } // Distance (in meters, intervals of 5)

        [Required]
        [RegularExpression(@"^([0-9]{1,2}):([0-5]?[0-9])\.[0-9]{1,2}$", ErrorMessage = "Time must be in the format mm:ss.xx (e.g., 1:23.45).")]
        public string? time { get; set; }

        [Range(20, 100, ErrorMessage = "How did you get it so high lol")] // Stroke rate
        public int? strokeRate { get; set; }

        [AllowedPaceAttribute(ErrorMessage = "Please select 50, 100, 200, 400, 800, 1500.")]
        public int? pace { get; set; }  // 50, 100, 200, 400, 800, 1500

        [Range(1, 10, ErrorMessage = "Please select 1, 2, 3, 4, 5, 6, 7, 8, 9, 10")] // Perceived exertion (scale of 1-10)
        public int? perceivedExertion { get; set; }

        [Range(40, 300)] // Heart rate (beats per minute)
        public int? heartRate { get; set; }

        public bool? dive { get; set; } // Whether the swim had a dive

        // One Swim can have Zero or More Splits (0 -> Many)
        public ICollection<Split>? splits { get; set; }  // One Swim can have many Splits
    }
}

public class MultipleOfFiveAttribute : ValidationAttribute
{
    public MultipleOfFiveAttribute() : base("The field must be a multiple of 5.") { }

    public override bool IsValid(object? value)
    {
        // Ensure value is an integer and a multiple of 5
        if (value is int intValue)
        {
            return intValue % 5 == 0;
        }
        return false;
    }
}

public class AllowedPaceAttribute : ValidationAttribute
{
    private readonly int[] _allowedPaces = { 50, 100, 200, 400, 800, 1500 };

    public AllowedPaceAttribute() : base("The pace must be one of the following values: 50, 100, 200, 400, 800, 1500.") { }

    public override bool IsValid(object? value)
    {
        if (value is int paceValue)
        {
            return _allowedPaces.Contains(paceValue);
        }
        return false;
    }
}

public class AllowedExertionValueAttribute : ValidationAttribute
{
    private readonly int[] _allowedValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public AllowedExertionValueAttribute() : base("The perceived exertion must be between 1 and 10.") { }

    public override bool IsValid(object? value)
    {
        if (value is int exertionValue)
        {
            return _allowedValues.Contains(exertionValue);
        }
        return false;
    }
}

public class AllowedStrokeAttribute : ValidationAttribute
{
    private readonly string[] _allowedStrokes = { "Freestyle", "Backstroke", "Breaststroke", "Butterfly", "IM" };

    public AllowedStrokeAttribute() : base("The stroke must be one of the following: Freestyle, Backstroke, Breaststroke, Butterfly, IM.") { }

    public override bool IsValid(object? value)
    {
        if (value is string strokeValue)
        {
            return _allowedStrokes.Contains(strokeValue);
        }
        return false;
    }
}
