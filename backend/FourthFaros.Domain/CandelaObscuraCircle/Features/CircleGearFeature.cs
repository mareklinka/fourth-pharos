using System.Collections.Immutable;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Features;

public sealed record CircleGearFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_gear";

    public override int Version => 1;

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();
}
