namespace SwimmingAppBackend.Models
{
    public class Squad
    {
        public int id { get; set; }

        required public int coachId { get; set; }
        required public CoachProfile coachProfile { get; set; }

        public int? clubId { get; set; }
        public Club? club { get; set; }

        required public string squadName { get; set; }

        public ICollection<SwimmerProfile>? swimmers { get; set; }
        public ICollection<Set>? sets { get; set; }
    }
}