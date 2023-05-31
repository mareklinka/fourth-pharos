using FourthFaros.Domain.CandelaObscuraCharacter.Features;
using FourthFaros.Domain.CandelaObscuraCharacter.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCharacter;

public static class CharacterFactory
{
    public static Character CreateCharacter(string name)
    {
        CharacterValidators.Name(name);

        return new Character().AddFeature(t => new CharacterBasicInfoFeature(t, name));
    }
}
