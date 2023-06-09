namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record CharacterRelationship(Guid Id, string Name, string? Description) : IAddressable;

