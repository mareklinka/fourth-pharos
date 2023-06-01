using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter;

public static class CharacterFactory
{
    public static Character CreateCharacter(string name)
    {
        CharacterValidators.Name(name);

        return new Character().AddFeature(t => new CharacterBasicInfoFeature(t, name));
    }
}