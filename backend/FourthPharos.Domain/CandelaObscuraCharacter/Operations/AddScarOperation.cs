using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class AddScarOperation
{
    public static Character AddScar(this Character character, ScarType scarType)
    {
        var feature = character.GetFeature<Character, CharacterScarsFeature>();

        return character.UpdateFeature(feature with
        {
            Scars = feature.Scars.Add(new(scarType))
        });
    }
}
