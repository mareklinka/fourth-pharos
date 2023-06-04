using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RemoveScarOperation
{
    public static Character RemoveScar(this Character character, Guid id)
    {
        var feature = character.GetFeature<Character, CharacterScarsFeature>();

        return feature.Scars.SingleOrDefault(_ => _.Id == id) switch
        {
            ScarModel scar => character.UpdateFeature(feature with { Scars = feature.Scars.Remove(scar) }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidScar(id)
        };
    }
}
