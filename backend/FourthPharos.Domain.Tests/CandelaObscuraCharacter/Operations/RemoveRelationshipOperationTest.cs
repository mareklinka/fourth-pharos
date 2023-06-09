using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class RemoveRelationshipOperationTest
{
    [Fact]
    public void RemoveRelationshipTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        var relationship = character
            .AddRelationship("Vitruvius", "Archnemesis, leader of the Serpent's Tail cult")
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldHaveSingleItem();

        character.RemoveRelationship(relationship.Id)
            .GetFeature<Character, CharacterRelationshipFeature>()
            .Relationships
            .ShouldBeEmpty();
    }

    [Fact]
    public void RemoveNonExistentRelationshipFails()
    {
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .RemoveRelationship(Guid.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidRelationship));
    }
}
