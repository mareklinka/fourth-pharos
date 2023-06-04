using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Models;

public record CircleAbility
{
    public static readonly ImmutableDictionary<string, CircleAbility> KnownAbilities = new Dictionary<string, CircleAbility>
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
    }.ToImmutableDictionary();

    private CircleAbility(string code, Func<Circle, Circle>? onAdded = null, Func<Circle, Circle>? onRemoved = null)
    {
        Code = code;
        OnAdded = onAdded;
        OnRemoved = onRemoved;
    }

    public static CircleAbility StaminaTraining { get; } = KnownAbilities["stm"];

    public static CircleAbility NobodyLeftBehind { get; } = KnownAbilities["nlb"];

    public static CircleAbility ForgedInFire { get; } = KnownAbilities["fif"];

    public static CircleAbility Interdisciplinary { get; } = KnownAbilities["int"];

    public static CircleAbility ResourceManagement { get; } = KnownAbilities["rm"];

    public static CircleAbility OneLastRun { get; } = KnownAbilities["olr"];

    public string Code { get; }

    public Func<Circle, Circle>? OnAdded { get; }

    public Func<Circle, Circle>? OnRemoved { get; }
}
