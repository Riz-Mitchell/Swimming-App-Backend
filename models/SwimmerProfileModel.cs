using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class SwimmerProfile
    {
        public int id { get; set; }

        // One SwimmerProfile has One  User (1 -> 1)
        public int userId { get; set; }
        required public User user { get; set; }

        public string? mainStroke;

        public int? mainDistance;

        public string? goalTime;

        public ICollection<Swim>? swims;
    }
}