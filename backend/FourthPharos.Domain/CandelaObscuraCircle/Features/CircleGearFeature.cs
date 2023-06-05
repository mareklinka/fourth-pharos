using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleGearFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_gear";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();
}
