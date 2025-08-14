using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Infrastructure.Models;
namespace SwimmingAppBackend.Api.DTOs
{
    public class GetSwimQuestionnaireDTO
    {
        public required Guid Id { get; set; } // Primary Key

        // Attributes:
        // ------------------------------------------------
        public required SelfTalkOptionsEnum SelfTalk { get; set; }
        public required NervesOptionsEnum Nerves { get; set; }
        public required EnergyLevelOptionsEnum EnergyLevel { get; set; }
        public required BreathingOptionsEnum Breathing { get; set; }
        public required CatchFeelOptionsEnum CatchFeel { get; set; }
        public required StrokeLengthOptionsEnum StrokeLength { get; set; }
        public required KickTechniqueOptionsEnum KickTechnique { get; set; }
        public required KickThroughoutOptionsEnum KickThroughout { get; set; }
        public required HeadPositionOptionsEnum HeadPosition { get; set; }
        public required TurnOptionsEnum Turn { get; set; }
    }

    public class CreateSwimQuestionnaireReqDTO
    {
        // Attributes:
        // ------------------------------------------------
        public required SelfTalkOptionsEnum SelfTalk { get; set; }
        public required NervesOptionsEnum Nerves { get; set; }
        public required EnergyLevelOptionsEnum EnergyLevel { get; set; }
        public required BreathingOptionsEnum Breathing { get; set; }
        public required CatchFeelOptionsEnum CatchFeel { get; set; }
        public required StrokeLengthOptionsEnum StrokeLength { get; set; }
        public required KickTechniqueOptionsEnum KickTechnique { get; set; }
        public required KickThroughoutOptionsEnum KickThroughout { get; set; }
        public required HeadPositionOptionsEnum HeadPosition { get; set; }
        public required TurnOptionsEnum Turn { get; set; }
    }

    public class UpdateSwimQuestionnaireReqDTO
    {
        public SelfTalkOptionsEnum? SelfTalk { get; set; }
        public NervesOptionsEnum? Nerves { get; set; }
        public EnergyLevelOptionsEnum? EnergyLevel { get; set; }
        public BreathingOptionsEnum? Breathing { get; set; }
        public CatchFeelOptionsEnum? CatchFeel { get; set; }
        public StrokeLengthOptionsEnum? StrokeLength { get; set; }
        public KickTechniqueOptionsEnum? KickTechnique { get; set; }
        public KickThroughoutOptionsEnum? KickThroughout { get; set; }
        public HeadPositionOptionsEnum? HeadPosition { get; set; }
        public TurnOptionsEnum? Turn { get; set; }
    }

    public static class SwimQuestionnaireMapper
    {
        public static GetSwimQuestionnaireDTO ModelToRes(SwimQuestionnaire swimQuestionnaire)
        {
            return new GetSwimQuestionnaireDTO
            {
                Id = swimQuestionnaire.Id,
                SelfTalk = swimQuestionnaire.SelfTalk,
                Nerves = swimQuestionnaire.Nerves,
                EnergyLevel = swimQuestionnaire.EnergyLevel,
                Breathing = swimQuestionnaire.Breathing,
                CatchFeel = swimQuestionnaire.CatchFeel,
                StrokeLength = swimQuestionnaire.StrokeLength,
                KickTechnique = swimQuestionnaire.KickTechnique,
                KickThroughout = swimQuestionnaire.KickThroughout,
                HeadPosition = swimQuestionnaire.HeadPosition,
                Turn = swimQuestionnaire.Turn
            };
        }
    }
}