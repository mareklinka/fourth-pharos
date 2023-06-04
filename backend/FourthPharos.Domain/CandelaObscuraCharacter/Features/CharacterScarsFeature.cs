using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterScarsFeature(Character Target) : FeatureBase<Character>(Target)
{
    public override string Code => "char_scars";

    public override int Version => 1;

    public ImmutableArray<ScarModel> Scars { get; init; } = ImmutableArray.Create<ScarModel>();
}