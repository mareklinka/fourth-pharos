using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleAbilitiesFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_abilities";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();

    public int MaximumAbilities => Target.GetFeature<CircleIlluminationFeature>().Rank;

    public int AvailableAbilities => Target.GetFeature<CircleIlluminationFeature>().Rank - Abilities.Length;
}