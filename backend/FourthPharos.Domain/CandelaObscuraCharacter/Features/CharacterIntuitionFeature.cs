using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterIntuitionFeature : CharacterDriveFeatureBase
{
    public const string SurveyActionCode = "survey";

    public const string FocusActionCode = "focus";

    public const string SenseActionCode = "sense";

    public CharacterIntuitionFeature(Character target) : base(target) =>
        Actions = ImmutableDictionary.CreateRange(new KeyValuePair<string, CharacterAction>[] {
            KeyValuePair.Create(SurveyActionCode, new CharacterAction(SurveyActionCode)),
            KeyValuePair.Create(FocusActionCode, new CharacterAction(FocusActionCode)),
            KeyValuePair.Create(SenseActionCode, new CharacterAction(SenseActionCode))
        });

    public override string Code => "char_drive_intuition";

    public override int Version => 1;
}
