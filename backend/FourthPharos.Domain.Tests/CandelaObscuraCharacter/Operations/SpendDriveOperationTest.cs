using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class SpendDriveOperationTest
{
    [Theory]
    [MemberData(nameof(Drives))]
    public void SpendNerveTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t));

        var feature = character.GetFeature<Character, CharacterNerveFeature>();

        character
            .UpdateFeature(feature with { Drive = drive })
            .SpendDrive<CharacterNerveFeature>()
            .GetFeature<Character, CharacterNerveFeature>()
            .Drive
            .ShouldBe(drive - 1);
    }

    [Fact]
    public void NotEnoughNerveTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterNerveFeature(t))
                .SpendDrive<CharacterNerveFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientDrive));
    }

    [Theory]
    [MemberData(nameof(Drives))]
    public void SpendCunningTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t));

        var feature = character.GetFeature<Character, CharacterCunningFeature>();

        character
            .UpdateFeature(feature with { Drive = drive })
            .SpendDrive<CharacterCunningFeature>()
            .GetFeature<Character, CharacterCunningFeature>()
            .Drive
            .ShouldBe(drive - 1);
    }

    [Fact]
    public void NotEnoughCunningTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterCunningFeature(t))
                .SpendDrive<CharacterCunningFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientDrive));
    }

    [Theory]
    [MemberData(nameof(Drives))]
    public void SpendIntuitionTest(int drive)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t));

        var feature = character.GetFeature<Character, CharacterIntuitionFeature>();

        character
            .UpdateFeature(feature with { Drive = drive })
            .SpendDrive<CharacterIntuitionFeature>()
            .GetFeature<Character, CharacterIntuitionFeature>()
            .Drive
            .ShouldBe(drive - 1);
    }

    [Fact]
    public void NotEnoughIntuitionTest()
    {
        Should.Throw<DomainActionException>(() =>
            CharacterFactory
                .CreateCharacter("Crowley Thornwood")
                .AddFeature(t => new CharacterIntuitionFeature(t))
                .SpendDrive<CharacterIntuitionFeature>())
        .Code
        .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientDrive));
    }

    public static IEnumerable<object[]> Drives => Enumerable.Range(1, 9).Select(_ => new object[] { _ });
}
