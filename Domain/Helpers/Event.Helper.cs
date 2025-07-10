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

        public static bool IsStrokeValid(Stroke stroke, EventEnum swimEvent)
        {
            if (IsIM(swimEvent))
            {
                return true;
            }

            switch (stroke)
            {
                case Stroke.Freestyle:
                    return swimEvent == EventEnum.Freestyle50
                        || swimEvent == EventEnum.Freestyle100
                        || swimEvent == EventEnum.Freestyle200
                        || swimEvent == EventEnum.Freestyle400
                        || swimEvent == EventEnum.Freestyle800
                        || swimEvent == EventEnum.Freestyle1500;
                case Stroke.Backstroke:
                    return swimEvent == EventEnum.Backstroke50
                        || swimEvent == EventEnum.Backstroke100
                        || swimEvent == EventEnum.Backstroke200;
                case Stroke.Breaststroke:
                    return swimEvent == EventEnum.Breaststroke50
                        || swimEvent == EventEnum.Breaststroke100
                        || swimEvent == EventEnum.Breaststroke200;
                case Stroke.Butterfly:
                    return swimEvent == EventEnum.Butterfly50
                        || swimEvent == EventEnum.Butterfly100
                        || swimEvent == EventEnum.Butterfly200;
                default:
                    return false;
            }
        }

        private static bool IsIM(EventEnum swimEvent)
        {
            if (swimEvent == EventEnum.IndividualMedley200 || swimEvent == EventEnum.IndividualMedley400) return true;
            else return false;
        }

        public static int GetDistance(EventEnum swimEvent)
        {
            if (EventDistances.TryGetValue(swimEvent, out int distance))
                return distance;

            throw new ArgumentOutOfRangeException(nameof(swimEvent), $"Unknown event: {swimEvent}");
        }
    }
}