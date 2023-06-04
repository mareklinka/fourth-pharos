using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterNotesFeature(Character Target) : FeatureBase<Character>(Target)
{
    public override string Code => "char_notes";

    public override int Version => 1;

    public ImmutableArray<CharacterNote> Notes { get; init; } = ImmutableArray.Create<CharacterNote>();
}
