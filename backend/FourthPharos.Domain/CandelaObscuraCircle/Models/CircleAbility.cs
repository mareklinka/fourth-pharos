using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Models;

public record CircleAbility
{
    public static readonly IReadOnlyDictionary<string, CircleAbility> Abilities = new Dictionary<string, CircleAbility>()
    {
        { "stm", new(
            "stm",
            t => t.AddFeature(t => new StaminaTrainingFeature(t)),
            t => t.RemoveFeature<Circle, StaminaTrainingFeature>()) },
        { "nlb", new("nlb") },
        { "fif", new("fif") },
        { "int", new("int") },
        { "rm", new("rm") },
        { "olr", new("olr") },
    };

    private CircleAbility(string code, Func<Circle, Circle>? onAdded = null, Func<Circle, Circle>? onRemoved = null)
    {
        Code = code;
        OnAdded = onAdded;
        OnRemoved = onRemoved;
    }

    public static CircleAbility StaminaTraining { get; } = Abilities["stm"];

    public static CircleAbility NobodyLeftBehind { get; } = Abilities["nlb"];

    public static CircleAbility ForgedInFire { get; } = Abilities["fif"];

    public static CircleAbility Interdisciplinary { get; } = Abilities["int"];

    public static CircleAbility ResourceManagement { get; } = Abilities["rm"];

    public static CircleAbility OneLastRun { get; } = Abilities["olr"];

    public string Code { get; }

    public Func<Circle, Circle>? OnAdded { get; }

    public Func<Circle, Circle>? OnRemoved { get; }

    public int TakenAtRank { get; init; }
}
