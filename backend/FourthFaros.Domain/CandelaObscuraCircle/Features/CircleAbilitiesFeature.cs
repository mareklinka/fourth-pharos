using System.Collections.Immutable;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Features;

public sealed record CircleAbilitiesFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_abilities";

    public override int Version => 1;

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();
}