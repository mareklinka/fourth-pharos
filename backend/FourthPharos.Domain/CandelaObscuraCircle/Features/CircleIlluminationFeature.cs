using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleIlluminationFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_illumination";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public int Illumination { get; init; }

    public CircleMilestone Milestone =>
        (Illumination % 24) switch
        {
            < 7 => CircleMilestone.None,
            < 14 => CircleMilestone.First,
            < 21 => CircleMilestone.Second,
            <= 23 => CircleMilestone.Third,
            _ => throw new InvalidOperationException("Illumination cannot exceed 24")
        };

    public int Rank => 1 + (Illumination / 24);

    public override object? GetData() => Illumination;

    public override CircleIlluminationFeature SetData(JToken? data) =>
        data switch
        {
            JValue { Type: JTokenType.Integer } v => this with { Illumination = v.Value<int>()! },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
