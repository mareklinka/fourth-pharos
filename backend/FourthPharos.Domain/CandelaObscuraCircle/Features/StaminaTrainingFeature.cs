using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record StaminaTrainingFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_stamina_training";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public int StaminaDice { get; init; } = 3;

    public override object? GetData() => StaminaDice;

    public override StaminaTrainingFeature SetData(JToken? data) =>
        data switch
        {
            JValue { Type: JTokenType.Integer } v => this with { StaminaDice = v.Value<int>()! },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
