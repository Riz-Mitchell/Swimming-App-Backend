namespace SwimmingAppBackend.Models
{
    public class Club
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<Squad> squads { get; set; }
    }
}