namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record CharacterNote(Guid Id, string? Text) : IAddressable;
