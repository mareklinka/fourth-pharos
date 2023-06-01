using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Features;

public class CharacterCunningFeatureTest
{
    [Fact]
    public void FeatureContainsCorrectActions()
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t))
            .GetFeature<Character, CharacterCunningFeature>();

        feature.Actions.Count.ShouldBe(3);
        feature.Actions.ShouldContainKey(CharacterCunningFeature.SwayActionCode);
        feature.Actions.ShouldContainKey(CharacterCunningFeature.ReadActionCode);
        feature.Actions.ShouldContainKey(CharacterCunningFeature.HideActionCode);

        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterCunningFeature.SwayActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterCunningFeature.ReadActionCode);
        feature.Actions.Values.ShouldContain(_ => _.Code == CharacterCunningFeature.HideActionCode);
    }

    [Theory]
    [InlineData(CharacterCunningFeature.SwayActionCode)]
    [InlineData(CharacterCunningFeature.ReadActionCode)]
    [InlineData(CharacterCunningFeature.HideActionCode)]
    public void DefaultFeatureContainsDefaultActions(string actionCode)
    {
        var feature = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t))
            .GetFeature<Character, CharacterCunningFeature>();

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
            .AddFeature(t => new CharacterCunningFeature(t))
            .GetFeature<Character, CharacterCunningFeature>()
            with
        { DriveMax = drive };

        feature.ResistanceMax.ShouldBe(drive / 3);
    }

    public static IEnumerable<object[]> Drives => Enumerable.Range(0, 10).Select(_ => new object[] { _ });
}
