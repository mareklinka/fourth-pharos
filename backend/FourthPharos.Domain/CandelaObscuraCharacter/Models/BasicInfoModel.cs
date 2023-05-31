namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record BasicInfoModel
{
    public string Name { get; init; } = null!;

    public string? Pronouns { get; init; }

    public string? Style { get; init; }

    public string? Catalyst { get; init; }

    public string? Question { get; init; }
}
