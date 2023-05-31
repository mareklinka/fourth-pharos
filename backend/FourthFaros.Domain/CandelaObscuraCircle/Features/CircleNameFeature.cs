using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Features;

public sealed record CircleNameFeature(Circle Target, string Name) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_name";

    public override int Version => 1;
}
