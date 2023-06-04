using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RemoveNoteOperation
{
    public static Character RemoveNote(this Character character, Guid id)
    {
        var feature = character.GetFeature<Character, CharacterNotesFeature>();

        return feature.Notes.SingleOrDefault(_ => _.Id == id) switch
        {
            CharacterNote note => character.UpdateFeature(feature with { Notes = feature.Notes.Remove(note) }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidNote(id)
        };
    }
}
