using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleLocationFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_location";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public string? Location { get; init; }
}