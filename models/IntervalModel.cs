namespace SwimmingAppBackend.Models
{
    public class Interval
    {
        public int id { get; set; }

        required public int meters { get; set; }

        required public int time { get; set; }

        public bool push { get; set; } = false;
    }
}