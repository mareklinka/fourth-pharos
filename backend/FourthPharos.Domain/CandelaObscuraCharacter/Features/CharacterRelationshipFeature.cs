using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterRelationshipFeature(Character Target) : FeatureBase<Character>(Target)
{
    public override string Code => "char_relationship";

    public override int Version => 1;

    public ImmutableArray<CharacterRelationship> Relationships { get; init; } = ImmutableArray.Create<CharacterRelationship>();
}