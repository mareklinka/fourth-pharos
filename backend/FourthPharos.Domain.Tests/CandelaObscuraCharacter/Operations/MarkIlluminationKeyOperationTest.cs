using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class MarkIlluminationKeyOperationTest
{
    [Fact]
    public void MarkIlluminationKeyTest()
    {
        var keys = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .SetRole(Models.CharacterSpecialty.Explorer)
            .MarkIlluminationKey("artifact", true)
            .GetFeature<Character, CharacterIlluminationKeysFeature>()
            .IlluminationKeys;

        keys.Count.ShouldBe(1);
        keys["artifact"].ShouldBeTrue();
    }

    [Fact]
    public void MarkIlluminationKeyInvalidKeyFailsTest()
    {
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .SetRole(Models.CharacterSpecialty.Explorer)
            .MarkIlluminationKey("__?__", true))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidIlluminationKey));
    }

    [Fact]
    public void MarkIlluminationKeyTrueAlreadyMarkedFailsTest()
    {
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .SetRole(Models.CharacterSpecialty.Explorer)
            .MarkIlluminationKey("artifact", true)
            .MarkIlluminationKey("artifact", true))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.IlluminationKeyAlreadyMarked));
    }

    [Fact]
    public void MarkIlluminationKeyFalseAlreadyMarkedFailsTest()
    {
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .SetRole(Models.CharacterSpecialty.Explorer)
            .MarkIlluminationKey("artifact", false))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.IlluminationKeyAlreadyMarked));
    }
}
