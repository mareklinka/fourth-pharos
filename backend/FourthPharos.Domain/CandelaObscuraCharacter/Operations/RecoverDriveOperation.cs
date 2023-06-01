using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class RecoverDriveOperation
{
    public static Character RecoverDrive<TFeature>(this Character character) where TFeature : CharacterDriveFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        return feature.Drive >= feature.DriveMax
            ? throw DomainExceptions.CharacterExceptions.MaximumDriveReached()
            : character.UpdateFeature(feature with { Drive = feature.Drive + 1 });
    }
}