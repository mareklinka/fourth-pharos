using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class SetActionGildedOperationTest
{
    [Theory]
    [InlineData(CharacterNerveFeature.MoveActionCode, true)]
    [InlineData(CharacterNerveFeature.StrikeActionCode, true)]
    [InlineData(CharacterNerveFeature.ControlActionCode, true)]
    [InlineData(CharacterNerveFeature.MoveActionCode, false)]
    [InlineData(CharacterNerveFeature.StrikeActionCode, false)]
    [InlineData(CharacterNerveFeature.ControlActionCode, false)]
    public void SetsNerveActionGilded(string actionCode, bool isGilded)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterNerveFeature(t));

        var feature = character.GetFeature<CharacterNerveFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { IsGilded = !isGilded }) })
            .SetActionGilded<CharacterNerveFeature>(actionCode, isGilded)
            .GetFeature<CharacterNerveFeature>()
            .Actions[actionCode]
            .IsGilded
            .ShouldBe(isGilded);
    }

    [Theory]
    [InlineData(CharacterCunningFeature.SwayActionCode, true)]
    [InlineData(CharacterCunningFeature.ReadActionCode, true)]
    [InlineData(CharacterCunningFeature.HideActionCode, true)]
    [InlineData(CharacterCunningFeature.SwayActionCode, false)]
    [InlineData(CharacterCunningFeature.ReadActionCode, false)]
    [InlineData(CharacterCunningFeature.HideActionCode, false)]
    public void SetsCunningActionGilded(string actionCode, bool isGilded)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterCunningFeature(t));

        var feature = character.GetFeature<CharacterCunningFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { IsGilded = !isGilded }) })
            .SetActionGilded<CharacterCunningFeature>(actionCode, isGilded)
            .GetFeature<CharacterCunningFeature>()
            .Actions[actionCode]
            .IsGilded
            .ShouldBe(isGilded);
    }

    [Theory]
    [InlineData(CharacterIntuitionFeature.SurveyActionCode, true)]
    [InlineData(CharacterIntuitionFeature.FocusActionCode, true)]
    [InlineData(CharacterIntuitionFeature.SenseActionCode, true)]
    [InlineData(CharacterIntuitionFeature.SurveyActionCode, false)]
    [InlineData(CharacterIntuitionFeature.FocusActionCode, false)]
    [InlineData(CharacterIntuitionFeature.SenseActionCode, false)]
    public void SetsIntuitionActionGilded(string actionCode, bool isGilded)
    {
        var character = CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddFeature(t => new CharacterIntuitionFeature(t));

        var feature = character.GetFeature<CharacterIntuitionFeature>();
        var action = feature.Actions[actionCode];

        character
            .UpdateFeature(feature with { Actions = feature.Actions.SetItem(actionCode, action with { IsGilded = !isGilded }) })
            .SetActionGilded<CharacterIntuitionFeature>(actionCode, isGilded)
            .GetFeature<CharacterIntuitionFeature>()
            .Actions[actionCode]
            .IsGilded
            .ShouldBe(isGilded);
    }
}
