using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class SetMaximumDriveOperation
{
    public static Character SetMaximumDrive<TFeature>(
        this Character character,
        int drive) where TFeature : CharacterDriveFeatureBase
    {
        var feature = character.GetFeature<Character, TFeature>();

        CharacterValidators.MaximumDrive(drive);

        return character.UpdateFeature(feature with { DriveMax = drive, Drive = Math.Min(feature.Drive, drive) });
    }
}
