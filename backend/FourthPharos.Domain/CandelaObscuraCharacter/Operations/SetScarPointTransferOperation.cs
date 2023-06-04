using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class SetScarPointTransferOperation
{
    public static Character SetScarPointTransfer(this Character character, Guid id, string? sourceAction, string? targetAction)
    {
        var feature = character.GetFeature<Character, CharacterScarsFeature>();

        CharacterValidators.ScarActionPointTransfer(sourceAction, targetAction);

        var nerveDriveFeature = character.GetFeature<Character, CharacterNerveFeature>();
        var cunningDriveFeature = character.GetFeature<Character, CharacterCunningFeature>();
        var intuitionDriveFeature = character.GetFeature<Character, CharacterIntuitionFeature>();

        var driveFeatures = new CharacterDriveFeatureBase[] { nerveDriveFeature, cunningDriveFeature, intuitionDriveFeature };

        ValidateDrive(sourceAction, targetAction, driveFeatures);

        return feature.Scars.SingleOrDefault(_ => _.Id == id) switch
        {
            ScarModel scar => character.UpdateFeature(feature with
            {
                Scars = feature
                    .Scars
                    .Remove(scar)
                    .Add(scar with
                    {
                        SourcePointActionCode = sourceAction,
                        TargetPointActionCode = targetAction
                    })
            }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidScar(id)
        };
    }

    private static void ValidateDrive(string? sourceAction, string? targetAction, CharacterDriveFeatureBase[] driveFeatures)
    {
        if (sourceAction is not null)
        {
            var feature = GetCorrespondingFeature(sourceAction, driveFeatures) ?? throw DomainExceptions.CharacterExceptions.InvalidAction(sourceAction);

            if (feature.Actions[sourceAction].Rating == 0)
            {
                throw DomainExceptions.CharacterExceptions.InsufficientActionRating(sourceAction);
            }
        }

        if (targetAction is not null)
        {
            var feature = GetCorrespondingFeature(targetAction, driveFeatures) ?? throw DomainExceptions.CharacterExceptions.InvalidAction(targetAction);

            if (feature.Actions[targetAction].Rating == 3)
            {
                throw DomainExceptions.CharacterExceptions.ActionRatingFull(targetAction);
            }
        }
    }

    private static CharacterDriveFeatureBase? GetCorrespondingFeature(
        string actionCode,
        CharacterDriveFeatureBase[] driveFeatures) =>
        driveFeatures.SingleOrDefault(_ => _.Actions.ContainsKey(actionCode));
}
