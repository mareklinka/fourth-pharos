using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class UpdateRelationshipOperation
{
    public static Character UpdateRelationship(this Character character, Guid id, string name, string? description = null)
    {
        var feature = character.GetFeature<Character, CharacterRelationshipFeature>();

        CharacterValidators.RelationshipName(name);
        CharacterValidators.RelationshipDescription(description);

        return feature.Relationships.SingleOrDefault(_ => _.Id == id) switch
        {
            CharacterRelationship r => character.UpdateFeature(feature with
            {
                Relationships = feature.Relationships.Remove(r).Add(r with { Name = name, Description = description })
            }),
            _ => throw DomainExceptions.CharacterExceptions.InvalidRelationship(id)
        };
    }
}