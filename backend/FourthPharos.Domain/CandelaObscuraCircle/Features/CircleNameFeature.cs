using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleNameFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_name";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public string Name { get; init; } = string.Empty;
}
