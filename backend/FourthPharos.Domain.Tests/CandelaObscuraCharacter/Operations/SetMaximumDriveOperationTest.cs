using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class SetMaximumDriveOperationTest
{
    [Theory]
    [MemberData(nameof(Drives))]
    public void SetsMaximumNerveDrive(int drive) =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t))
            .SetMaximumDrive<CharacterNerveFeature>(drive)
            .GetFeature<CharacterNerveFeature>()
            .DriveMax
            .ShouldBe(drive);

    [Theory]
    [MemberData(nameof(Drives))]
    public void DecreasesRemainingNerveDrive(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t));

        var feature = character.GetFeature<CharacterNerveFeature>();

        character
            .UpdateFeature(feature with { Drive = 10 })
            .SetMaximumDrive<CharacterNerveFeature>(drive)
            .GetFeature<CharacterNerveFeature>()
            .Drive
            .ShouldBe(drive);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(10)]
    public void ValidatesMaximumNerveDrive(int drive) =>
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterNerveFeature(t))
                .SetMaximumDrive<CharacterNerveFeature>(drive)
                .GetFeature<CharacterNerveFeature>()
                .DriveMax
                .ShouldBe(drive))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveOutOfRange));

    [Theory]
    [MemberData(nameof(Drives))]
    public void SetsMaximumCunningDrive(int drive) =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t))
            .SetMaximumDrive<CharacterCunningFeature>(drive)
            .GetFeature<CharacterCunningFeature>()
            .DriveMax
            .ShouldBe(drive);

    [Theory]
    [MemberData(nameof(Drives))]
    public void DecreasesRemainingCunningDrive(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t));

        var feature = character.GetFeature<CharacterCunningFeature>();

        character
            .UpdateFeature(feature with { Drive = 10 })
            .SetMaximumDrive<CharacterCunningFeature>(drive)
            .GetFeature<CharacterCunningFeature>()
            .Drive
            .ShouldBe(drive);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(10)]
    public void ValidatesMaximumCunningDrive(int drive) =>
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterCunningFeature(t))
                .SetMaximumDrive<CharacterCunningFeature>(drive)
                .GetFeature<CharacterCunningFeature>()
                .DriveMax
                .ShouldBe(drive))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveOutOfRange));

    [Theory]
    [MemberData(nameof(Drives))]
    public void SetsMaximumIntuitionDrive(int drive) =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t))
            .SetMaximumDrive<CharacterIntuitionFeature>(drive)
            .GetFeature<CharacterIntuitionFeature>()
            .DriveMax
            .ShouldBe(drive);

    [Theory]
    [MemberData(nameof(Drives))]
    public void DecreasesRemainingIntuitionDrive(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t));

        var feature = character.GetFeature<CharacterIntuitionFeature>();

        character
            .UpdateFeature(feature with { Drive = 10 })
            .SetMaximumDrive<CharacterIntuitionFeature>(drive)
            .GetFeature<CharacterIntuitionFeature>()
            .Drive
            .ShouldBe(drive);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(10)]
    public void ValidatesMaximumIntuitionDrive(int drive) =>
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterIntuitionFeature(t))
                .SetMaximumDrive<CharacterIntuitionFeature>(drive)
                .GetFeature<CharacterIntuitionFeature>()
                .DriveMax
                .ShouldBe(drive))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveOutOfRange));

    public static IEnumerable<object[]> Drives => Enumerable.Range(0, 10).Select(_ => new object[] { _ });
}
