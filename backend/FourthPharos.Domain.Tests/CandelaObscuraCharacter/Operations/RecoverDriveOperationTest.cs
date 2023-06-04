using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class RecoverDriveOperationTest
{
    [Theory]
    [MemberData(nameof(Drives))]
    public void RecoverNerveTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t));

        var feature = character.GetFeature<Character, CharacterNerveFeature>();

        character
            .UpdateFeature(feature with { Drive = drive, DriveMax = 9 })
            .RecoverDrive<CharacterNerveFeature>()
            .GetFeature<Character, CharacterNerveFeature>()
            .Drive
            .ShouldBe(drive + 1);
    }

    [Fact]
    public void MaximumNerveTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterNerveFeature(t))
                .RecoverDrive<CharacterNerveFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveReached));
    }

    [Theory]
    [MemberData(nameof(Drives))]
    public void RecoverCunningTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t));

        var feature = character.GetFeature<Character, CharacterCunningFeature>();

        character
            .UpdateFeature(feature with { Drive = drive, DriveMax = 9 })
            .RecoverDrive<CharacterCunningFeature>()
            .GetFeature<Character, CharacterCunningFeature>()
            .Drive
            .ShouldBe(drive + 1);
    }

    [Fact]
    public void MaximumCunningTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterCunningFeature(t))
                .RecoverDrive<CharacterCunningFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveReached));
    }

    [Theory]
    [MemberData(nameof(Drives))]
    public void RecoverIntuitionTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t));

        var feature = character.GetFeature<Character, CharacterIntuitionFeature>();

        character
            .UpdateFeature(feature with { Drive = drive, DriveMax = 9 })
            .RecoverDrive<CharacterIntuitionFeature>()
            .GetFeature<Character, CharacterIntuitionFeature>()
            .Drive
            .ShouldBe(drive + 1);
    }

    [Fact]
    public void MaximumIntuitionTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterIntuitionFeature(t))
                .RecoverDrive<CharacterIntuitionFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.MaximumDriveReached));
    }

    public static IEnumerable<object[]> Drives => Enumerable.Range(0, 9).Select(_ => new object[] { _ });
}
