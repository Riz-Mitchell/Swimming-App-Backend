namespace SwimmingAppBackend.Domain.Helpers
{
    public static class InterpolationHelper
    {
        public static double GetPotentialRaceTime(List<SplitData> data, double splitTime, int distance)
        {
            var ordered = data
                .Where(d => d.SplitsByDistance.ContainsKey(distance))
                .OrderBy(d => d.SplitsByDistance[distance])
                .ToList();

            for (int i = 0; i < ordered.Count - 1; i++)
            {
                double t1 = ordered[i].SplitsByDistance[distance];
                double t2 = ordered[i + 1].SplitsByDistance[distance];

                if (splitTime >= t1 && splitTime <= t2)
                {
                    double y1 = ordered[i].TotalTime;
                    double y2 = ordered[i + 1].TotalTime;

                    // Linear interpolation
                    return y1 + (splitTime - t1) * (y2 - y1) / (t2 - t1);
                }
            }

            // Outside known range – scaling from nearest point
            var nearest = ordered
                .OrderBy(d => Math.Abs(d.SplitsByDistance[distance] - splitTime))
                .First();

            double nearestSplit = nearest.SplitsByDistance[distance];
            double nearestTotal = nearest.TotalTime;

            // Scale total time proportionally
            return nearestTotal * (splitTime / nearestSplit);
        }

        public static double GetPotentialSplitTime(List<SplitData> data, double totalTime, int distance)
        {
            var ordered = data
                .Where(d => d.SplitsByDistance.ContainsKey(distance))
                .OrderBy(d => d.TotalTime)
                .ToList();

            for (int i = 0; i < ordered.Count - 1; i++)
            {
                double y1 = ordered[i].TotalTime;
                double y2 = ordered[i + 1].TotalTime;

                if (totalTime >= y1 && totalTime <= y2)
                {
                    double x1 = ordered[i].SplitsByDistance[distance];
                    double x2 = ordered[i + 1].SplitsByDistance[distance];

                    // Linear interpolation (inverse)
                    return x1 + (totalTime - y1) * (x2 - x1) / (y2 - y1);
                }
            }

            // Outside known range – scale from nearest point
            var nearest = ordered
                .OrderBy(d => Math.Abs(d.TotalTime - totalTime))
                .First();

            double nearestTotal = nearest.TotalTime;
            double nearestSplit = nearest.SplitsByDistance[distance];

            return nearestSplit * (totalTime / nearestTotal);
        }
    }


    public class SplitData
    {
        public double TotalTime { get; set; }
        public Dictionary<int, double> SplitsByDistance { get; set; } = [];
    }
}