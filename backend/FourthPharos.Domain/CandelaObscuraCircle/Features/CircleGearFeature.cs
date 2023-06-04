using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleGearFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_gear";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();

    public override object? GetData() => Gear.Select(_ => _.Name).ToArray();

    public override CircleGearFeature SetData(JToken? data) =>
        data switch
        {
            JArray a => this with
            {
                Gear = ImmutableArray.CreateRange(a.Values<string>()!.Select(_ => new CircleGear(_!)))
            },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
