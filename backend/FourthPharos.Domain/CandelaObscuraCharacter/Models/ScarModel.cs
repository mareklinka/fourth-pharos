namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record ScarModel(ScarType Type)
{
    public string? Description { get; init; }
}
