using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class UpdateScarDescriptionOperation
{
    public static Character UpdateScarDescription(this Character character, ScarModel scar, string description)
    {
        var feature = character.GetFeature<Character, CharacterScarsFeature>();

        CharacterValidators.ScarDescription(description);

        return character.UpdateFeature(feature with
        {
            Scars = feature.Scars.Remove(scar).Add(scar with { Description = description })
        });
    }
}
