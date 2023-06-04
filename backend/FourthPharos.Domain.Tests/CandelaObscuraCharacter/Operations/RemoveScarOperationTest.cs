using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class RemoveScarOperationTest
{
    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void RemoveScar(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        character
            .RemoveScar(scar.Id)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .ShouldBeEmpty();
    }
}
