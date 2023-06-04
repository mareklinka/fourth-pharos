namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record ScarModel(Guid Id, ScarType Type, DateTime Timestamp) : IAddressable
{
    public string? Description { get; init; }

    public string? SourcePointActionCode { get; init; }

    public string? TargetPointActionCode { get; init; }
}
