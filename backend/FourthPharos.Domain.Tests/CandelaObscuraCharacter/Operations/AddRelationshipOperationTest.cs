using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class AddRelationshipOperationTest
{
    [Fact]
    public void AddRelationshipTest()
    {
        var relationship = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddRelationship("Vitruvius", "Archnemesis, leader of the Serpent's Tail cult")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        relationship.Name.ShouldBe("Vitruvius");
        relationship.Description.ShouldBe("Archnemesis, leader of the Serpent's Tail cult");
    }

    [Fact]
    public void AddRelationshipNameTooLongFails() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddRelationship(new string('a', CharacterValidators.RelationshipNameMaxLength + 1)))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.RelationshipNameTooLong));

    [Fact]
    public void AddRelationshipDescriptionTooLongFails() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddRelationship("Vitruvius", new string('a', CharacterValidators.RelationshipDescriptionMaxLength + 1)))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.RelationshipDescriptionTooLong));
}
