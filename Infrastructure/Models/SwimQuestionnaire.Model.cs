using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Infrastructure.Models
{
    public class SwimQuestionnaire
    {
        public Guid Id { get; set; } = new Guid(); // Primary Key

        // Attrubutes :
        // ------------------------------------------------
        public SelfTalkOptionsEnum SelfTalk { get; set; }
        public List<NervesOptionsEnum> Nerves { get; set; }
        public EnergyLevelOptionsEnum EnergyLevel { get; set; }
        public BreathingOptionsEnum Breathing { get; set; }
        public List<CatchFeelOptionsEnum> CatchFeel { get; set; }
        public StrokeLengthOptionsEnum StrokeLength { get; set; }
        public KickTechniqueOptionsEnum KickTechnique { get; set; }
        public KickThroughoutOptionsEnum KickThroughout { get; set; }
        public List<HeadPositionOptionsEnum> HeadPosition { get; set; }
        public List<TurnOptionsEnum> Turn { get; set; }

        // ------------------------------------------------
    }
}