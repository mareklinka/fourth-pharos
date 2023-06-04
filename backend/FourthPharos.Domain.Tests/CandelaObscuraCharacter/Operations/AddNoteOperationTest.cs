using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class AddNoteOperationTest
{
    [Fact]
    public void AddNoteTest() =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddNote("Has a recurring dream of a rat gnawing on a black rose")
            .GetFeature<Character, CharacterNotesFeature>()
            .Notes
            .ShouldHaveSingleItem()
            .Text
            .ShouldBe("Has a recurring dream of a rat gnawing on a black rose");
}
