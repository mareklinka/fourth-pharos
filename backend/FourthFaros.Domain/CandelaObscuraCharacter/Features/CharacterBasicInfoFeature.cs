using FourthFaros.Domain.CandelaObscuraCharacter.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterBasicInfoFeature(Character Target, string Name) : FeatureBase<Character>(Target)
{
    public override string Code => "char_basic_info";

    public override int Version => 1;

    public string? Pronouns { get; init; }

    public string? Style { get; init; }

    public string? Catalyst { get; init; }

    public string? Question { get; init; }
}
