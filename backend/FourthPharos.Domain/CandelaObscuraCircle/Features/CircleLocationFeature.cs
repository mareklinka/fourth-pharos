using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleLocationFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_location";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public string? Location { get; init; }

    public override object? GetData() => Location;

    public override CircleLocationFeature SetData(JToken? data) =>
        data switch
        {
            JValue { Type: JTokenType.Null } => this with { Location = null },
            JValue { Type: JTokenType.String } v => this with { Location = v.Value<string>()! },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}