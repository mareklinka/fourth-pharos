namespace FourthPharos.Domain.CandelaObscuraCircle.Models;

public record CircleAbility
{
    public static readonly IReadOnlyDictionary<string, CircleAbility> Abilities = new Dictionary<string, CircleAbility>()
    {
        { "stm", new("stm") },
        { "nlb", new("nlb") },
        { "fif", new("fif") },
        { "int", new("int") },
        { "rm", new("rm") },
        { "olr", new("olr") },
    };

    private CircleAbility(string code) => Code = code;

    public static CircleAbility StaminaTraining { get; } = Abilities["stm"];

    public static CircleAbility NobodyLeftBehind { get; } = Abilities["nlb"];

    public static CircleAbility ForgedInFire { get; } = Abilities["fif"];

    public static CircleAbility Interdisciplinary { get; } = Abilities["int"];

    public static CircleAbility ResourceManagement { get; } = Abilities["rm"];

    public static CircleAbility OneLastRun { get; } = Abilities["olr"];

    public string Code { get; }

    public int TakenAtRank { get; init; }
}
