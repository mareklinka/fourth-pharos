using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterNerveFeature : CharacterDriveFeatureBase
{
    public const string MoveActionCode = "move";

    public const string StrikeActionCode = "strike";

    public const string ControlActionCode = "control";

    public CharacterNerveFeature(Character target) : base(target) =>
        Actions = ImmutableDictionary.CreateRange(new KeyValuePair<string, CharacterAction>[] {
            KeyValuePair.Create(MoveActionCode, new CharacterAction(MoveActionCode)),
            KeyValuePair.Create(StrikeActionCode, new CharacterAction(StrikeActionCode)),
            KeyValuePair.Create(ControlActionCode, new CharacterAction(ControlActionCode))
        });

    public override string Code => "char_drive_nerve";

    public override int Version => 1;
}
