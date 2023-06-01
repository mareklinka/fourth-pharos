using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Features;

public class CharacterNerveFeatureTest
{
    [Fact]
    public void FeatureContainsCorrectActions()
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t))
            .GetFeature<Character, CharacterNerveFeature>();

        feature.Actions.Count.ShouldBe(3);
        feature.Actions.ShouldContainKey(CharacterNerveFeature.MoveActionCode);
        feature.Actions.ShouldContainKey(CharacterNerveFeature.StrikeActionCode);
        feature.Actions.ShouldContainKey(CharacterNerveFeature.ControlActionCode);

        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterNerveFeature.MoveActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterNerveFeature.StrikeActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterNerveFeature.ControlActionCode);
    }

    [Theory]
    [InlineData(CharacterNerveFeature.MoveActionCode)]
    [InlineData(CharacterNerveFeature.StrikeActionCode)]
    [InlineData(CharacterNerveFeature.ControlActionCode)]
    public void DefaultFeatureContainsDefaultActions(string actionCode)
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t))
            .GetFeature<Character, CharacterNerveFeature>();

        var action = feature.Actions[actionCode];
        action.Rating.ShouldBe(0);
        action.IsGilded.ShouldBeFalse();
    }

    [Theory]
    [MemberData(nameof(Drives))]
    public void HasCorrectResistance(int drive)
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t))
            .GetFeature<Character, CharacterNerveFeature>()
            with
        { DriveMax = drive };

        feature.ResistanceMax.ShouldBe(drive / 3);
    }

    public static IEnumerable<object[]> Drives => Enumerable.Range(0, 10).Select(_ => new object[] { _ });
}
