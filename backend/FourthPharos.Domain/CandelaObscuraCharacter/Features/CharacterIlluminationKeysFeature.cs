using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterIlluminationKeysFeature(Character Target) : FeatureBase<Character>(Target)
{
    public override string Code => "char_illumination_keys";

    public override int Version => 1;

    // in the full game, this is most likely going to change to a switch on Specialty instead
    public IReadOnlyCollection<string> AvailableIlluminationKeys =>
        Target.GetFeature<Character, CharacterRoleFeature>().Role switch
        {
            CharacterRole.Face => new[] { "trick", "ruse", "magick" },
            CharacterRole.Muscle => new[] { "artifact", "history", "danger" },
            CharacterRole.Scholar => new[] { "mentor", "research", "plan" },
            CharacterRole.Slink => new[] { "illegal", "deal", "authority" },
            CharacterRole.Weird => new[] { "texts", "oddities", "bizzare" },
            _ => throw new InvalidOperationException("Unknown role")
        };

    public ImmutableDictionary<string, bool> IlluminationKeys { get; init; } =
        ImmutableDictionary.Create<string, bool>();
}
