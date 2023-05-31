using System.Collections.Immutable;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleGearFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_gear";

    public override int Version => 1;

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();
}
