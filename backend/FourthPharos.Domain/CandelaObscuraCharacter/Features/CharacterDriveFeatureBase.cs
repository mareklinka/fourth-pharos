using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public abstract record CharacterDriveFeatureBase(Character Target) : FeatureBase<Character>(Target)
{
    public int Drive { get; init; }

    public int DriveMax { get; init; }

    public ImmutableDictionary<string, CharacterAction> Actions { get; init; } = ImmutableDictionary.Create<string, CharacterAction>();

    public int Resistance { get; init; }

    public int ResistanceMax => DriveMax / 3;
}
