namespace SwimmingAppBackend.Models
{
    public class CoachProfile
    {
        public int id { get; set; }

        public int userId { get; set; }
        public User user { get; set; }

        public ICollection<Squad>? squads { get; set; }
    }
}