using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class UpdateNoteOperation
{
    public static Character UpdateNote(this Character character, Guid id, string? text)
    {
        var feature = character.GetFeature<Character, CharacterNotesFeature>();

        return feature.Notes.SingleOrDefault(_ => _.Id == id) switch
        {
            CharacterNote note => character.UpdateFeature(feature with
            {
                Notes = feature
                    .Notes
                    .Insert(feature.Notes.IndexOf(note), note with { Text = text })
                    .Remove(note)
            }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidNote(id)
        };
    }
}
