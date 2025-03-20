using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class SwimmerProfile
    {
        public int id { get; set; }

        // One SwimmerProfile has One  User (1 -> 1)
        required public int userId { get; set; }
        required public User user { get; set; }

        public int? squadId { get; set; }
        public Squad? squad { get; set; }

        public string? mainStroke { get; set; }

        public int? mainDistance { get; set; }

        public string? goalTime { get; set; }

        public ICollection<Swim>? swims { get; set; }
    }
}