using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleAbilitiesFeatureTest
{
    [Fact]
    public void DefaultAbilityLimitTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .MaximumAbilities
            .ShouldBe(1);

    [Fact]
    public void DefaultAvailableAbilityTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .AvailableAbilities
            .ShouldBe(1);

    [Fact]
    public void AddingAbilityDecreasesAvailableAbilities() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .AvailableAbilities
            .ShouldBe(0);

    [Fact]
    public void PersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(200)
            .AddAbility(CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.Interdisciplinary)
            .AddAbility(CircleAbility.NobodyLeftBehind)
            .AddAbility(CircleAbility.OneLastRun)
            .AddAbility(CircleAbility.ResourceManagement)
            .AddAbility(CircleAbility.StaminaTraining)
            .GetFeature<Circle, CircleAbilitiesFeature>();

        var json = JToken.FromObject(feature.GetData()!);

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Abilities.ShouldBe(deserialized.Abilities);
    }
}
