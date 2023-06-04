using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterBasicInfoFeature(Character Target, string Name) : FeatureBase<Character>(Target)
{
    public override string Code => "char_basic_info";

    public override int Version => 1;

    public string? Pronouns { get; init; }

    public string? Style { get; init; }

    public string? Catalyst { get; init; }

    public string? Question { get; init; }

    public override object GetData() => new { Name, Pronouns, Style, Catalyst, Question };

    public override FeatureBase<Character> SetData(JToken? data) =>
        data switch
        {
            JObject o => this with
            {
                Name = o.GetValue(nameof(Name), StringComparison.OrdinalIgnoreCase)!.Value<string>() ?? string.Empty,
                Pronouns = o.GetValue(nameof(Pronouns), StringComparison.OrdinalIgnoreCase)?.Value<string>(),
                Style = o.GetValue(nameof(Style), StringComparison.OrdinalIgnoreCase)?.Value<string>(),
                Catalyst = o.GetValue(nameof(Catalyst), StringComparison.OrdinalIgnoreCase)?.Value<string>(),
                Question = o.GetValue(nameof(Question), StringComparison.OrdinalIgnoreCase)?.Value<string>(),
            },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
