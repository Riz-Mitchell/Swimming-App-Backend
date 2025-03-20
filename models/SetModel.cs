namespace SwimmingAppBackend.Models
{
    public class Set
    {
        public int id { get; set; }

        required public int squadId { get; set; }
        required public Squad squad { get; set; }

        public string? quoteOfTheSet { get; set; }
    }
}