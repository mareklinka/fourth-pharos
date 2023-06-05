using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterBasicInfoFeature(Character Target, string Name) : FeatureBase<Character>(Target)
{
    public override string Code => "char_basic_info";

    public override int Version => 1;

    public string? Pronouns { get; init; }

    public string? Style { get; init; }

    public string? Catalyst { get; init; }

    public string? Question { get; init; }

    public static FeatureBase<Character> Create(Character target) => throw new NotImplementedException();
}
