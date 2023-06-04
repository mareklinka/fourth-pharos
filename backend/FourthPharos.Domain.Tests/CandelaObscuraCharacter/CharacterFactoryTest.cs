using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter;

public class CharacterFactoryTest
{
    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CharacterFactory.CreateCharacter(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CharacterFactory.CreateCharacter(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CharacterFactory.CreateCharacter(new string('a', CharacterValidators.BasicInfoMaxLength + 1)));
        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }

    [Fact]
    public void NewCharacterHasCorrectFeatures() =>
        Should.NotThrow(() =>
        {
            var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

            character.Features.Count.ShouldBe(2);

            character.GetFeature<Character, CharacterBasicInfoFeature>();
            character.GetFeature<Character, CharacterNotesFeature>();
        });

    [Fact]
    public void NewCharacterHasCorrectBasicInfo()
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .GetFeature<Character, CharacterBasicInfoFeature>();

        feature.Name.ShouldBe("Crowley Thornwood");
        feature.Pronouns.ShouldBeNull();
        feature.Question.ShouldBeNull();
        feature.Catalyst.ShouldBeNull();
        feature.Style.ShouldBeNull();
    }
}
