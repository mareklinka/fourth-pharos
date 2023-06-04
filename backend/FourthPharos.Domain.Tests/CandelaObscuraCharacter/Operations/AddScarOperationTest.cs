using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class AddScarOperationTest
{
    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void AddScar(ScarType type)
    {
        var scar = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .ShouldHaveSingleItem();

        scar.Type.ShouldBe(type);
        scar.Description.ShouldBeNull();
    }
}
