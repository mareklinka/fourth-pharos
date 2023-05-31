using System.Collections.Immutable;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleAbilitiesFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_abilities";

    public override int Version => 1;

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();
}