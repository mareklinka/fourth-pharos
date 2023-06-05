using System.Collections.Immutable;
using FourthPharos.Domain;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Persistence;

public static class CircleFeatureDataExtensions
{
    public static object? GetFeatureData<TFeature>(this TFeature feature) where TFeature : FeatureBase<Circle> =>
        feature switch
        {
            CircleNameFeature f => f.Name,
            CircleLocationFeature f => f.Location,
            StaminaTrainingFeature f => f.StaminaDice,
            CircleResourcesFeature f => f.Resources,
            CircleIlluminationFeature f => f.Illumination,
            CircleGearFeature f => f.Gear.Select(_ => _.Name).ToArray(),
            CircleAbilitiesFeature f => f.Abilities.Select(_ => _.Code).ToArray(),
            _ => throw new InvalidOperationException("Unknown feature encountered")
        };

    public static TFeature SetFeatureData<TFeature>(this TFeature feature, JToken? data) where TFeature : FeatureBase<Circle> =>
        feature switch
        {
            CircleNameFeature f => (TFeature)(object)(f with
            {
                Name = data switch
                {
                    JValue { Type: JTokenType.String } v => v.Value<string>()!,
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            CircleLocationFeature f => (TFeature)(object)(f with
            {
                Location = data switch
                {
                    JValue { Type: JTokenType.Null } => null,
                    JValue { Type: JTokenType.String } v => v.Value<string>(),
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            StaminaTrainingFeature f => (TFeature)(object)(f with
            {
                StaminaDice = data switch
                {
                    JValue { Type: JTokenType.Integer } v => v.Value<int>(),
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            CircleResourcesFeature f => (TFeature)(object)(f with
            {
                Resources = data switch
                {
                    JObject o => ImmutableDictionary.CreateRange(o
                            .Properties()
                            .Select(_ => KeyValuePair.Create(Enum.Parse<CircleResource>(_.Name, ignoreCase: true), _.Value.Value<int>()!))),
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            CircleIlluminationFeature f => (TFeature)(object)(f with
            {
                Illumination = data switch
                {
                    JValue { Type: JTokenType.Integer } v => v.Value<int>()!,
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            CircleGearFeature f => (TFeature)(object)(f with
            {
                Gear = data switch
                {
                    JArray a => ImmutableArray.CreateRange(a.Values<string>()!.Select(_ => new CircleGear(_!))),
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            CircleAbilitiesFeature f => (TFeature)(object)(f with
            {
                Abilities = data switch
                {
                    JArray a => ImmutableArray.CreateRange(a.Values<string>()!.Select(_ => CircleAbility.KnownAbilities[_!])),
                    _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(f.Code, f.Version, data)
                }
            }),
            _ => throw new InvalidOperationException("Unknown feature encountered")
        };
}