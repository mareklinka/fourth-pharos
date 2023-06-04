using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class AddMarkOperation
{
    public static Character AddMark<TFeature>(this Character character)
        where TFeature : CharacterMarksFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        return feature.Marks switch
        {
            < 3 => character.UpdateFeature(feature with { Marks = feature.Marks + 1 }),
            _ => character.AddScar(feature.ScarType).UpdateFeature(feature with { Marks = 0 })
        };
    }
}
