using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleAbilitiesFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_abilities";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();

    public int MaximumAbilities => Target.GetFeature<Circle, CircleIlluminationFeature>().Rank;

    public int AvailableAbilities => Target.GetFeature<Circle, CircleIlluminationFeature>().Rank - Abilities.Length;

    public override object? GetData() => Abilities.Select(_ => _.Code).ToArray();

    public override CircleAbilitiesFeature SetData(JToken? data) =>
        data switch
        {
            JArray a => this with
            {
                Abilities = ImmutableArray.CreateRange(a.Values<string>()!.Select(_ => CircleAbility.KnownAbilities[_!]))
            },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}