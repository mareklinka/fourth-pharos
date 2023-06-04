using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RemoveScarOperation
{
    public static Character RemoveScar(this Character character, ScarModel scar)
    {
        var feature = character.GetFeature<Character, CharacterScarsFeature>();

        return character.UpdateFeature(feature with
        {
            Scars = feature.Scars.Remove(scar)
        });
    }
}
