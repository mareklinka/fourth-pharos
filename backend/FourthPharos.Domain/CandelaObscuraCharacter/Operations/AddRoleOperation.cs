using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class AddRoleOperation
{
    public static Character AddRole(this Character character, CharacterSpecialty specialty)
    {
        var feature = character.GetFeature<Character, CharacterRoleFeature>();

        return character.UpdateFeature(feature with { Specialty = specialty });
    }
}