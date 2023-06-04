using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleNameFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_name";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public string Name { get; init; } = string.Empty;

    public override object? GetData() => Name;

    public override CircleNameFeature SetData(JToken? data) =>
        data switch
        {
            JValue { Type: JTokenType.String } v => this with { Name = v.Value<string>()! },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
