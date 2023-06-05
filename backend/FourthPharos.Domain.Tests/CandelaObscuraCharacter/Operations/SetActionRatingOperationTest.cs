using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class SetActionRatingOperationTest
{
    [Theory]
    [MemberData(nameof(NerveRatings))]
    public void SetsNerveActionRating(string actionCode, int rating)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t));

        var feature = character.GetFeature<CharacterNerveFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { Rating = -1 }) })
            .SetActionRating<CharacterNerveFeature>(actionCode, rating)
            .GetFeature<CharacterNerveFeature>()
            .Actions[actionCode]
            .Rating
            .ShouldBe(rating);
    }

    [Theory]
    [MemberData(nameof(CunningRatings))]
    public void SetsCunningActionRating(string actionCode, int rating)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t));

        var feature = character.GetFeature<CharacterCunningFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { Rating = -1 }) })
            .SetActionRating<CharacterCunningFeature>(actionCode, rating)
            .GetFeature<CharacterCunningFeature>()
            .Actions[actionCode]
            .Rating
            .ShouldBe(rating);
    }

    [Theory]
    [MemberData(nameof(IntuitionRatings))]
    public void SetsIntuitionActionRating(string actionCode, int rating)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t));

        var feature = character.GetFeature<CharacterIntuitionFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { Rating = -1 }) })
            .SetActionRating<CharacterIntuitionFeature>(actionCode, rating)
            .GetFeature<CharacterIntuitionFeature>()
            .Actions[actionCode]
            .Rating
            .ShouldBe(rating);
    }

    public static IEnumerable<object[]> NerveRatings =>
        BuildTestData(
            CharacterNerveFeature.MoveActionCode,
            CharacterNerveFeature.StrikeActionCode,
            CharacterNerveFeature.ControlActionCode);

    public static IEnumerable<object[]> CunningRatings =>
        BuildTestData(
            CharacterCunningFeature.SwayActionCode,
            CharacterCunningFeature.ReadActionCode,
            CharacterCunningFeature.HideActionCode);

    public static IEnumerable<object[]> IntuitionRatings =>
        BuildTestData(
            CharacterIntuitionFeature.SurveyActionCode,
            CharacterIntuitionFeature.FocusActionCode,
            CharacterIntuitionFeature.SenseActionCode);

    private static IEnumerable<object[]> BuildTestData(params string[] actionCodes)
    {
        foreach (var code in actionCodes)
        {
            foreach (var i in Enumerable.Range(0, 4))
            {
                yield return new object[] { code, i };
            }
        }
    }
}