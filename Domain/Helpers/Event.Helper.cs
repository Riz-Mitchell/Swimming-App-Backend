using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Domain.Helpers
{
    public class EventHelper
    {
        private static readonly Dictionary<EventEnum, int> EventDistances = new()
        {
            { EventEnum.Freestyle50, 50 },
            { EventEnum.Freestyle100, 100 },
            { EventEnum.Freestyle200, 200 },
            { EventEnum.Freestyle400, 400 },
            { EventEnum.Freestyle800, 800 },
            { EventEnum.Freestyle1500, 1500 },
            { EventEnum.Backstroke50, 50 },
            { EventEnum.Backstroke100, 100 },
            { EventEnum.Backstroke200, 200 },
            { EventEnum.Butterfly50, 50 },
            { EventEnum.Butterfly100, 100 },
            { EventEnum.Butterfly200, 200 },
            { EventEnum.Breaststroke50, 50 },
            { EventEnum.Breaststroke100, 100 },
            { EventEnum.Breaststroke200, 200 },
            { EventEnum.IndividualMedley200, 200 },
            { EventEnum.IndividualMedley400, 400 },
        };

        public static int GetDistance(EventEnum swimEvent)
        {
            if (EventDistances.TryGetValue(swimEvent, out int distance))
                return distance;

            throw new ArgumentOutOfRangeException(nameof(swimEvent), $"Unknown event: {swimEvent}");
        }
    }
}