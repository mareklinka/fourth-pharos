using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class UpdateScarDescriptionOperationTest
{
    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void UpdateScarDescription(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        character
            .UpdateScarDescription(scar, "Painful limp")
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .ShouldHaveSingleItem()
            .Description
            .ShouldBe("Painful limp");
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void UpdateFailsForLongDescriptionsDescription(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .UpdateScarDescription(scar, new string('a', CharacterValidators.ScarDescriptionMaxLength + 1)))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.ScarDescriptionTooLong));
    }
}