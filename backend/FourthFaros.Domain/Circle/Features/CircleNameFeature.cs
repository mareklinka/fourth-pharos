using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleNameFeature(CircleBase Target, string Name) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_name";

    public override int Version => 1;
}
