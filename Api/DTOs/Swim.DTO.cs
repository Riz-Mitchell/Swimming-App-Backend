
using SwimmingAppBackend.Enum;
namespace SwimmingAppBackend.Api.DTOs
{
    public class GetSwimsQuery
    {
        public Guid? UserId { get; set; }
        public EventEnum? Event { get; set; }
        public bool OnlyPersonalBest { get; set; } = false;
        public bool OnlyGoalSwim { get; set; } = false;
        public bool OnlyDive { get; set; } = false;

        public TimePeriod? TimePeriod { get; set; } = Enum.TimePeriod.Week;


        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetSwimResDTO
    {
        public required Guid Id { get; set; }  // Primary Key
        public required EventEnum Event { get; set; } // Event type
        public required ICollection<GetSplitResDTO> Splits { get; set; }
        public required GetSwimQuestionnaireDTO SwimQuestionnaire { get; set; } // Swim Questionnaire

        public required bool GoalSwim { get; set; }
        public required DateTime RecordedAt { get; set; }
        public required PoolType PoolType { get; set; }
    }

    public class CreateSwimReqDTO
    {
        public required EventEnum Event { get; set; } // Event type
        public required ICollection<CreateSplitReqDTO> Splits { get; set; } = [];
        public required CreateSwimQuestionnaireReqDTO SwimQuestionnaire { get; set; } // Swim Questionnaire
        public bool GoalSwim { get; set; } = false;
        public PoolType PoolType { get; set; } = PoolType.LongCourseMeters;
    }


    public class UpdateSwimReqDTO
    {
        public EventEnum? Event { get; set; } // Event type
        public bool? GoalSwim { get; set; }
    }
}