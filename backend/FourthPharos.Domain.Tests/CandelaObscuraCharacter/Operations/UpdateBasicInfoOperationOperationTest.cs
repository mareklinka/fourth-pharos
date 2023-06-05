using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class UpdateBasicInfoOperationOperationTest
{
    [Fact]
    public void UpdateBasicInfo()
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .UpdateBasicInfo(new()
            {
                Name = "Carver Steelspike",
                Pronouns = "He/Him",
                Catalyst = "Found a magickal music box",
                Question = "Where does the music come from?",
                Style = "Alice in Wonderland"
            })
            .GetFeature<CharacterBasicInfoFeature>();

        feature.Name.ShouldBe("Carver Steelspike");
        feature.Pronouns.ShouldBe("He/Him");
        feature.Catalyst.ShouldBe("Found a magickal music box");
        feature.Question.ShouldBe("Where does the music come from?");
        feature.Style.ShouldBe("Alice in Wonderland");
    }

    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new() { Name = string.Empty }))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new() { Name = " \t" }))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new() { Name = new string('a', CharacterValidators.BasicInfoMaxLength + 1) }));

        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.CharacterNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }

    [Fact]
    public void PronounsMustNotExceedMaxLength()
    {
        var ex = Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new()
                {
                    Name = "Crowley Thornwood",
                    Pronouns = new('a', CharacterValidators.BasicInfoMaxLength + 1)
                }));

        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.BasicInfoTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }

    [Fact]
    public void CatalystMustNotExceedMaxLength()
    {
        var ex = Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new()
                {
                    Name = "Crowley Thornwood",
                    Catalyst = new('a', CharacterValidators.BasicInfoMaxLength + 1)
                }));

        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.BasicInfoTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }

    [Fact]
    public void QuestionMustNotExceedMaxLength()
    {
        var ex = Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new()
                {
                    Name = "Crowley Thornwood",
                    Question = new('a', CharacterValidators.BasicInfoMaxLength + 1)
                }));

        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.BasicInfoTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }

    [Fact]
    public void StyleMustNotExceedMaxLength()
    {
        var ex = Should
            .Throw<DomainActionException>(() => CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .UpdateBasicInfo(new()
                {
                    Name = "Crowley Thornwood",
                    Style = new('a', CharacterValidators.BasicInfoMaxLength + 1)
                }));

        ex.Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.BasicInfoTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CharacterValidators.BasicInfoMaxLength);
    }
}
