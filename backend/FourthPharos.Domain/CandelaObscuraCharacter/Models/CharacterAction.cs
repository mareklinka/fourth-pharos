namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record CharacterAction(string Code)
{
    public int Rating { get; init; }

    public bool IsGilded { get; init; }
}