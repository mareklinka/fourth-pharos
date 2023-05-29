namespace FourthFaros.Domain.Circle.Models;

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
