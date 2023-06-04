using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class UpdateNoteOperationTest
{
    [Fact]
    public void UpdateNoteTest()
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var id = character
            .AddNote("Has a recurring dream of a rat gnawing on a black rose")
            .GetFeature<Character, CharacterNotesFeature>()
            .Notes
            .Single()
            .Id;

        character
            .UpdateNote(id, "Has a recurring dream of an old, crooked tower")
            .GetFeature<Character, CharacterNotesFeature>()
            .Notes
            .ShouldHaveSingleItem()
            .Text
            .ShouldBe("Has a recurring dream of an old, crooked tower");
    }
}
