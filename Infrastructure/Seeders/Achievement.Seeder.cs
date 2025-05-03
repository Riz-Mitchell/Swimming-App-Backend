using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Seeders
{
    public static class AchievementSeeder
    {
        public static List<Achievement> GetPredifinedAchievements()
        {
            return
            [
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Marathon Swimmer",
                    Description = "Swim a total of 10,000 meters.",
                    TargetValue = 10000, // sum of Distance
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                // Number of swims logged
                // ------------------------------------------------
                    new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "First Swim",
                    Description = "Log your first swim session.",
                    TargetValue = 1,
                    Difficulty = 1,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Getting it done",
                    Description = "Log 20 swims.",
                    TargetValue = 20, // count of Swim entries
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                    new Achievement {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Busy cooking",
                    Description = "Log 100 swims.",
                    TargetValue = 100, // count of Swim entries
                    Difficulty = 3,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Proper chef",
                    Description = "Log 200 swims.",
                    TargetValue = 200, // count of Swim entries
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Name = "Gotta do at least 20 bro",
                    Description = "You made your first 1000, congratulations, we gotta do at least 20 bro. Log 1000 swims.",
                    TargetValue = 1000, // count of Swim entries
                    Difficulty = 8,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Ashton Hall",
                    Description = "How did you do that? Log 2000 swims",
                    TargetValue = 2000,
                    Difficulty = 10,
                    UserType = Enum.UserType.Swimmer

                },
                // ------------------------------------------------
                // Account age
                // ------------------------------------------------
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                    Name = "Unc status",
                    Description = "Account over a year old.",
                    TargetValue = 1,
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    Name = "Fossil",
                    Description = "Account over 2 years old.",
                    TargetValue = 1,
                    Difficulty = 8,
                    UserType = Enum.UserType.Swimmer
                },
                // ------------------------------------------------
                // Join bracket
                // ------------------------------------------------
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    Name = "Founding member",
                    Description = "One of the first 20 users to join.",
                    TargetValue = 1,
                    Difficulty = 10,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                    Name = "Early adopter",
                    Description = "One of the first 100 users to join.",
                    TargetValue = 1,
                    Difficulty = 8,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                    Name = "First 1000",
                    Description = "One of the first 1000 users to join.",
                    TargetValue = 1,
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                // ------------------------------------------------
                // Swim types
                // ------------------------------------------------
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                    Name = "Freestyle beginner",
                    Description = "Log 10 freestyle swims.",
                    TargetValue = 10, // count of Swim entries with Stroke == Freestyle
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                    Name = "Freestyle connoisseur",
                    Description = "Log 50 freestyle swims.",
                    TargetValue = 50, // count of Swim entries with Stroke == IM
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    Name = "Freestyle king",
                    Description = "Log 100 freestyle swims.",
                    TargetValue = 100, // count of Swim entries with Stroke == Breaststroke
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                    Name = "Breaststroke beginner",
                    Description = "Log 10 breaststroke swims.",
                    TargetValue = 10, // count of Swim entries with Stroke == Freestyle
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                    Name = "Breaststroke connoisseur",
                    Description = "Log 50 breaststroke swims.",
                    TargetValue = 50, // count of Swim entries with Stroke == IM
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                    Name = "Breaststroke king",
                    Description = "Log 100 breaststroke swims.",
                    TargetValue = 100, // count of Swim entries with Stroke == Breaststroke
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                    Name = "Backstroke beginner",
                    Description = "Log 10 backstroke swims.",
                    TargetValue = 10, // count of Swim entries with Stroke == Freestyle
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    Name = "Backstroke connoisseur",
                    Description = "Log 50 backstroke swims.",
                    TargetValue = 50, // count of Swim entries with Stroke == IM
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                    Name = "Backstroke king",
                    Description = "Log 100 backstroke swims.",
                    TargetValue = 100, // count of Swim entries with Stroke == Breaststroke
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                    Name = "Butterfly beginner",
                    Description = "Log 10 butterfly swims.",
                    TargetValue = 10, // count of Swim entries with Stroke == Freestyle
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                    Name = "Butterfly connoisseur",
                    Description = "Log 50 butterfly swims.",
                    TargetValue = 50, // count of Swim entries with Stroke == IM
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                    Name = "Butterfly king",
                    Description = "Log 100 butterfly swims.",
                    TargetValue = 100, // count of Swim entries with Stroke == Breaststroke
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                    Name = "IM beginner",
                    Description = "Log 10 IM swims.",
                    TargetValue = 10, // count of Swim entries with Stroke == Freestyle
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000026"),
                    Name = "IM connoisseur",
                    Description = "Log 50 IM swims.",
                    TargetValue = 50, // count of Swim entries with Stroke == IM
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000027"),
                    Name = "IM king",
                    Description = "Log 100 IM swims.",
                    TargetValue = 100, // count of Swim entries with Stroke == Breaststroke
                    Difficulty = 6,
                    UserType = Enum.UserType.Swimmer
                },

                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000028"),
                    Name = "Stroke Master",
                    Description = "Log swims in all four strokes.",
                    TargetValue = 4, // count of unique Stroke enums used
                    Difficulty = 3,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000029"),
                    Name = "PB Chaser",
                    Description = "Beat your personal best time for any event.",
                    TargetValue = 1, // perhaps boolean-triggered
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    Name = "Goal Getter",
                    Description = "Achieve a goal swim time.",
                    TargetValue = 1, // count of GoalSwim == true && %OffGoalTime <= 0
                    Difficulty = 3,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                    Name = "Morning Grind",
                    Description = "Log 10 swims before 7 AM.",
                    TargetValue = 10,
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000032"),
                    Name = "Alright maybe you should sleep in",
                    Description = "Log 10 swims before 6 AM.",
                    TargetValue = 10,
                    Difficulty = 5,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000033"),
                    Name = "Dying early",
                    Description = "Log 50 swims before 5:30AM.",
                    TargetValue = 50,
                    Difficulty = 8,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000034"),
                    Name = "Social Swimmer",
                    Description = "Make 5 friends.",
                    TargetValue = 5, // via separate friend relationship
                    Difficulty = 2,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000035"),
                    Name = "Great guy, amazing guy",
                    Description = "Make 20 friends.",
                    TargetValue = 5, // via separate friend relationship
                    Difficulty = 4,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000036"),
                    Name = "Exertion King",
                    Description = "Log a swim with a perceived exertion of 10.",
                    TargetValue = 1,
                    Difficulty = 1,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000037"),
                    Name = "Try hard",
                    Description = "Swim a 200m event with a perceived exertion of 10.",
                    TargetValue = 1,
                    Difficulty = 3,
                    UserType = Enum.UserType.Swimmer
                },
                new Achievement
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000038"),
                    Name = "I need a break. AHHHHHHH I NEED A BREAK!!!!",
                    Description = "Log 5 swims with a perceived exertion of 8 or more in a span of 30 minutes.",
                    TargetValue = 1,
                    Difficulty = 7,
                    UserType = Enum.UserType.Swimmer
                }
            ];
        }
    }
}