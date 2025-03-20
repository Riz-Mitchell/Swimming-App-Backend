using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwimmingAppBackend.Models
{
    public class User
    {
        public int id { get; set; }

        required public string phoneNum { get; set; }

        required public string name { get; set; }

        public int? age { get; set; }

        public string? email { get; set; }

        public SwimmerProfile? swimmerProfile { get; set; }

        public CoachProfile? coachProfile { get; set; }

        // public Link? ProfilePicture { get; set; }

    }
}