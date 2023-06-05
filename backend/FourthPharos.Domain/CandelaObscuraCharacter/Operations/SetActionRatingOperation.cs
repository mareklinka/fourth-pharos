using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class SetActionRatingOperation
{
    public static Character SetActionRating<TFeature>(
        this Character character,
        string actionCode,
        int rating) where TFeature : CharacterDriveFeatureBase
    {
        var feature = character.GetFeature<TFeature>();

        CharacterValidators.ActionRating(rating);

        return feature.Actions.TryGetValue(actionCode, out var action)
            ? character.UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { Rating = rating }) })
            : throw DomainExceptions.CharacterExceptions.InvalidAction(actionCode);
    }
}