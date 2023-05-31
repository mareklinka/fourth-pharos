using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleLocationFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_location";

    public override int Version => 1;

    public string? Location { get; init; }
}