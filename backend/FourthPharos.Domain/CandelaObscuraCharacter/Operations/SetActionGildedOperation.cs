using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class SetActionGildedOperation
{
    public static Character SetActionGilded<TFeature>(
        this Character character,
        string actionCode,
        bool isGilded) where TFeature : CharacterDriveFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        return feature.Actions.TryGetValue(actionCode, out var action)
            ? character.UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { IsGilded = isGilded }) })
            : throw DomainExceptions.CharacterExceptions.InvalidAction(actionCode);
    }
}
