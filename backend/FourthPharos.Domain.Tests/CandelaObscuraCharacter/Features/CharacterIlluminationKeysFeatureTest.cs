using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Features;

public class CharacterIlluminationKeysFeatureTest
{
    [Theory]
    [MemberData(nameof(Specialties))]
    public void FeatureContainsCorrectAvailablelluminationKeys(CharacterSpecialty specialty)
    {
        var keys = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .SetRole(specialty)
            .GetFeature<Character, CharacterIlluminationKeysFeature>()
            .AvailableIlluminationKeys;

        keys.Count.ShouldBe(3);
    }

    public static IEnumerable<object[]> Specialties =>
        Enum.GetValues<CharacterSpecialty>().Select(_ => new object[] { _ });
}
