using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterCunningFeature : CharacterDriveFeatureBase
{
    public const string SwayActionCode = "sway";
    public const string ReadActionCode = "read";
    public const string HideActionCode = "hide";

    public CharacterCunningFeature(Character target) : base(target) =>
        Actions = ImmutableDictionary.CreateRange(new KeyValuePair<string, CharacterAction>[] {
            KeyValuePair.Create(SwayActionCode, new CharacterAction(SwayActionCode)),
            KeyValuePair.Create(ReadActionCode, new CharacterAction(ReadActionCode)),
            KeyValuePair.Create(HideActionCode, new CharacterAction(HideActionCode))
        });

    public override string Code => "char_drive_cunning";

    public override int Version => 1;
}