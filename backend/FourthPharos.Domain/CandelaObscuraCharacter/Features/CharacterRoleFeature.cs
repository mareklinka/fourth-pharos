using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterRoleFeature(Character Target, CharacterSpecialty Specialty) : FeatureBase<Character>(Target)
{
    public override string Code => "char_role";

    public CharacterRole Role => Specialty switch
    {
        CharacterSpecialty.Journalist or CharacterSpecialty.Magician => CharacterRole.Face,
        CharacterSpecialty.Explorer or CharacterSpecialty.Soldier => CharacterRole.Muscle,
        CharacterSpecialty.Doctor or CharacterSpecialty.Professor => CharacterRole.Scholar,
        CharacterSpecialty.Criminal or CharacterSpecialty.Detective => CharacterRole.Slink,
        CharacterSpecialty.Medium or CharacterSpecialty.Occultist => CharacterRole.Weird,
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        _ => throw ApplicationExceptions.MissingRoleAssignment(Specialty)
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
    };

    public override int Version => 1;
}