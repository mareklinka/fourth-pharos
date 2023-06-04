using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RemoveMarkOperation
{
    public static Character RemoveMark<TFeature>(this Character character)
        where TFeature : CharacterMarksFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        return feature.Marks switch
        {
            >= 1 => character.UpdateFeature(feature with { Marks = feature.Marks - 1 }),
            _ => throw DomainExceptions.CharacterExceptions.InsufficientMarks()
        };
    }
}
