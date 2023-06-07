using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleAbilitiesFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_abilities";

    public override int Version => 1;

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();

    public int MaximumAbilities => Target.GetFeature<Circle, CircleIlluminationFeature>().Rank;

    public int AvailableAbilities => Target.GetFeature<Circle, CircleIlluminationFeature>().Rank - Abilities.Length;
}
