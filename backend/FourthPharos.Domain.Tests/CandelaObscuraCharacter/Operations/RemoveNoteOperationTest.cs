using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class RemoveNoteOperationTest
{
    [Fact]
    public void RemoveNoteTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var id = character
            .AddNote("Has a recurring dream of a rat gnawing on a black rose")
            .GetFeature<Character, CharacterNotesFeature>()
            .Notes
            .Single()
            .Id;

        character
            .RemoveNote(id)
            .GetFeature<Character, CharacterNotesFeature>()
            .Notes
            .ShouldBeEmpty();
    }

    [Fact]
    public void RemoveNonExistentNoteFails() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .RemoveNote(Guid.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidNote));

}
