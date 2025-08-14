// Only 1 can be selected at a time
public enum SelfTalkOptionsEnum
{
    Unselected, // assets/svg/unselected.svg
    None, // assets/svg/self_talk/none.svg
    MotivationalPositive, // assets/svg/self_talk/motivational_positive.svg
    MotivationalNegative, // assets/svg/self_talk/motivational_negative.svg
    InstructivePositive, // assets/svg/self_talk/instructional_positive.svg
    InstructiveNegative, // assets/svg/self_talk/instructional_negative.svg
    OutcomePositive, // assets/svg/self_talk/outcome_positive.svg
    OutcomeNegative // assets/svg/self_talk/outcome_negative.svg
}

// Multiple options can be selected
public enum NervesOptionsEnum
{
    Unselected, // assets/svg/unselected.svg
    Relaxed, // Muscles loose, calm body
    Jittery, // Shaky or twitchy (adrenaline)
    Tense, // Stiff muscles, clenched jaw, tight shoulders
    Heavy, // Legs or arms feel slow, weighed down
    Light, // Bouncy, springy, ready to go
    Nauseous // Stomach discomfort, classic nervous gut
}

// Only 1 can be selected at a time
public enum EnergyLevelOptionsEnum
{
    Unselected,
    Low, // Tired, sluggish, no energy
    Moderate, // Some energy, not fully charged
    High, // Full of energy, ready to go
    VeryHigh // Overly energetic, hyperactive
}

// Only 1 can be selected at a time
public enum BreathingOptionsEnum
{
    Unselected,
    Normal, // Calm, steady breathing
    Fast, // Quick, shallow breaths
    Deep, // Long, deep breaths
    Erratic // Inconsistent, uneven breathing
}

// Multiple options can be selected
public enum CatchFeelOptionsEnum
{
    Unselected,
    Strong,
    Weak,
    Slipping,
    Wide,
    Narrow
}

// Only 1 can be selected at a time
public enum StrokeLengthOptionsEnum
{
    Unselected,
    Longer,
    Shorter
}

// Only 1 can be selected at a time
public enum KickTechniqueOptionsEnum
{
    Unselected,
    Small,
    Big
}

// Only 1 can be selected at a time
public enum KickThroughoutOptionsEnum
{
    Unselected,
    Consistent,
    SpeedingUp,
    SlowingDown
}

// Multiple can be selected at a time
public enum HeadPositionOptionsEnum
{
    Unselected,
    LookingForward,
    LookingDown,
    HeadHigh,
    HeadLow,
    HeadNeutral
}

// Multiple can be selected at a time
public enum TurnOptionsEnum
{
    Unselected,
    Good,
    TooFar,
    TooClose,
    FeltSlow,
    FeltFast
}
