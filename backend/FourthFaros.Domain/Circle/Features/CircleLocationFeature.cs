using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleLocationFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_location";

    public override int Version => 1;

    public string? Location { get; init; }
}