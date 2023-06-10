using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class MarkIlluminationKeyOperation
{
    public static Character MarkIlluminationKey(this Character character, string keyCode, bool isMarked)
    {
        var feature = character.GetFeature<Character, CharacterIlluminationKeysFeature>();

        if (!feature.AvailableIlluminationKeys.Contains(keyCode))
        {
            throw DomainExceptions.CharacterExceptions.InvalidIlluminationKey(keyCode);
        }

        feature.IlluminationKeys.TryGetValue(keyCode, out var existing);

        if (existing == isMarked)
        {
            throw DomainExceptions.CharacterExceptions.IlluminationKeyAlreadyMarked(keyCode);
        }

        return character.UpdateFeature(feature with
        {
            IlluminationKeys = feature.IlluminationKeys.SetItem(keyCode, isMarked)
        });
    }
}
