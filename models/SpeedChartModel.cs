using System.Numerics;
using System.Runtime.ExceptionServices;

namespace SwimmingAppBackend.Models
{
    public class SpeedChart
    {
        public int id { get; set; }

        required public string stroke { get; set; }

        required public int pace { get; set; }      // Pace chart race length

        required public float totalTime { get; set; }

        required public float first50 { get; set; }

        public float? second50 { get; set; }

        required public ICollection<Interval> intervals { get; set; }

    }
}