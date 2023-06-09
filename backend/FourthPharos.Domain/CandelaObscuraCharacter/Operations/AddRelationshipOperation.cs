using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class AddRelationshipOperation
{
    public static Character AddRelationship(this Character character, string name, string? description = null)
    {
        var feature = character.GetFeature<Character, CharacterRelationshipFeature>();

        CharacterValidators.RelationshipName(name);
        CharacterValidators.RelationshipDescription(description);

        return character.UpdateFeature(feature with
        {
            Relationships = feature.Relationships.Add(new(Guid.NewGuid(), name, description))
        });
    }
}

