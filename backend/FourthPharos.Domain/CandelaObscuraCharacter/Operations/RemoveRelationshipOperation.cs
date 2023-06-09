using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RemoveRelationshipOperation
{
    public static Character RemoveRelationship(this Character character, Guid id)
    {
        var feature = character.GetFeature<Character, CharacterRelationshipFeature>();

        return feature.Relationships.SingleOrDefault(_ => _.Id == id) switch
        {
            CharacterRelationship r => character.UpdateFeature(feature with
            {
                Relationships = feature.Relationships.Remove(r)
            }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidRelationship(id)
        };
    }
}

