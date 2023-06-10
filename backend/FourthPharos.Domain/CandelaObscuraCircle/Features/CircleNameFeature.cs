using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleNameFeature(Circle Target, string? Name) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_name";

    public override int Version => 1;
}
