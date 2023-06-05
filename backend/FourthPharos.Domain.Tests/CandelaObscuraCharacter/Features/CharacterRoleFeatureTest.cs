using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Features;

public class CharacterRoleFeatureTest
{
    [Theory]
    [InlineData(CharacterSpecialty.Journalist, CharacterRole.Face)]
    [InlineData(CharacterSpecialty.Magician, CharacterRole.Face)]
    [InlineData(CharacterSpecialty.Explorer, CharacterRole.Muscle)]
    [InlineData(CharacterSpecialty.Soldier, CharacterRole.Muscle)]
    [InlineData(CharacterSpecialty.Doctor, CharacterRole.Scholar)]
    [InlineData(CharacterSpecialty.Professor, CharacterRole.Scholar)]
    [InlineData(CharacterSpecialty.Criminal, CharacterRole.Slink)]
    [InlineData(CharacterSpecialty.Detective, CharacterRole.Slink)]
    [InlineData(CharacterSpecialty.Medium, CharacterRole.Weird)]
    [InlineData(CharacterSpecialty.Occultist, CharacterRole.Weird)]
    public void RoleAndSpecialtyInitialized(CharacterSpecialty specialty, CharacterRole role)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood");

        var feature = character.UpdateFeature(new CharacterRoleFeature(character, specialty))
            .GetFeature<Character, CharacterRoleFeature>();

        feature.Specialty.ShouldBe(specialty);
        feature.Role.ShouldBe(role);
    }

    [Fact]
    public void ThrowsErrorOnUnassignedSpecialty()
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood");

        Should
            .Throw<DomainActionException>(() => new CharacterRoleFeature(character, (CharacterSpecialty)150))
            .Code
            .ShouldBe(nameof(ApplicationExceptions.MissingRoleAssignment));
    }
}