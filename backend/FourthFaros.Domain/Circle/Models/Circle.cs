using System.Collections.Immutable;

namespace FourthFaros.Domain.Circle.Models;

public record CircleBase(string Name, string? Location = null)
{
    public CircleMilestone Milestone =>
        Illumination switch
        {
            < 7 => CircleMilestone.None,
            < 14 => CircleMilestone.First,
            < 21 => CircleMilestone.Second,
            <= 23 => CircleMilestone.Third,
            _ => throw new InvalidOperationException("Illumination cannot exceed 24")
        };

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();

    public ImmutableArray<object> Characters { get; init; } = ImmutableArray.Create<object>();

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();


    public int Illumination { get; init; }

    public int StitchRemaining { get; init; } = 1;

    public int StitchMaximum => Characters.Length + 1;

    public int RefreshRemaining { get; init; } = 1;

    public int RefreshMaximum => Characters.Length + 1;

    public int TrainingRemaining { get; init; } = 1;

    public int TrainMaximum => Characters.Length + 1;

    public int Rank { get; init; } = 1;
}

public record CircleGear(string Name);

public record CircleAbility
{
    private static readonly Dictionary<string, CircleAbility> _abilities = new()
    {
        { "stm", new("stm") },
        { "nlb", new("nlb") },
        { "fif", new("fif") },
        { "int", new("int") },
        { "rm", new("rm") },
        { "olr", new("olr") },
    };

    private CircleAbility(string code) => Code = code;

    public static CircleAbility StaminaTraining { get; } = _abilities["stm"];

    public static CircleAbility NobodyLeftBehind { get; } = _abilities["nlb"];

    public static CircleAbility ForgedInFire { get; } = _abilities["fif"];

    public static CircleAbility Interdisciplinary { get; } = _abilities["int"];

    public static CircleAbility ResourceManagement { get; } = _abilities["rm"];

    public static CircleAbility OneLastRun { get; } = _abilities["olr"];

    public string Code { get; }
}