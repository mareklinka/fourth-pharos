using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class UpdateRelationshipOperationTest
{
    [Fact]
    public void UpdateRelationshipTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        var relationship = character
            .AddRelationship("Vitruvius", "Archnemesis, leader of the Serpent's Tail cult")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        relationship = character
            .UpdateRelationship(relationship.Id, "Arorinius", "A childhood friend lost to the Redfog mines")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        relationship.Name.ShouldBe("Arorinius");
        relationship.Description.ShouldBe("A childhood friend lost to the Redfog mines");
    }

    [Fact]
    public void UpdateRelationshipNameTooLongFailsTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        var relationship = character
            .AddRelationship("Vitruvius", "Archnemesis, leader of the Serpent's Tail cult")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        Should.Throw<DomainActionException>(() => character
            .UpdateRelationship(relationship.Id, new string('a', CharacterValidators.RelationshipNameMaxLength + 1)))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.RelationshipNameTooLong));
    }

    [Fact]
    public void UpdateRelationshipDescriptionTooLongFailsTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        var relationship = character
            .AddRelationship("Vitruvius", "Archnemesis, leader of the Serpent's Tail cult")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        Should.Throw<DomainActionException>(() => character
            .UpdateRelationship(relationship.Id, "Arorinius", new string('a', CharacterValidators.RelationshipDescriptionMaxLength + 1)))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.RelationshipDescriptionTooLong));
    }
}