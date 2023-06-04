using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class AddNoteOperation
{
    public static Character AddNote(this Character character, string? text)
    {
        var feature = character.GetFeature<Character, CharacterNotesFeature>();

        return character.UpdateFeature(feature with { Notes = feature.Notes.Add(new(Guid.NewGuid(), text)) });
    }
}
