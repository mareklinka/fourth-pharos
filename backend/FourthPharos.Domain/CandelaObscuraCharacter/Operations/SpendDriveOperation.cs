using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class SpendDriveOperation
{
    public static Character SpendDrive<TFeature>(this Character character) where TFeature : CharacterDriveFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        return feature.Drive switch
        {
            < 1 => throw DomainExceptions.CharacterExceptions.InsufficientDrive(),
            int d => character.UpdateFeature(feature with { Drive = d - 1 })
        };
    }
}
