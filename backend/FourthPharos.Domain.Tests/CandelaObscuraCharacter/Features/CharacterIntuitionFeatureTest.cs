using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Features;

public class CharacterIntuitionFeatureTest
{
    [Fact]
    public void FeatureContainsCorrectActions()
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .GetFeature<Character, CharacterIntuitionFeature>();

        feature.Actions.Count.ShouldBe(3);
        feature.Actions.ShouldContainKey(CharacterIntuitionFeature.SurveyActionCode);
        feature.Actions.ShouldContainKey(CharacterIntuitionFeature.FocusActionCode);
        feature.Actions.ShouldContainKey(CharacterIntuitionFeature.SenseActionCode);

        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterIntuitionFeature.SurveyActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterIntuitionFeature.FocusActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterIntuitionFeature.SenseActionCode);
    }

    [Theory]
    [InlineData(CharacterIntuitionFeature.SurveyActionCode)]
    [InlineData(CharacterIntuitionFeature.FocusActionCode)]
    [InlineData(CharacterIntuitionFeature.SenseActionCode)]
    public void DefaultFeatureContainsDefaultActions(string actionCode)
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .GetFeature<Character, CharacterIntuitionFeature>();

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
            .GetFeature<Character, CharacterIntuitionFeature>()
            with
        { DriveMax = drive };

        feature.ResistanceMax.ShouldBe(drive / 3);
    }

    public static IEnumerable<object[]> Drives => Enumerable.Range(0, 10).Select(_ => new object[] { _ });
}
