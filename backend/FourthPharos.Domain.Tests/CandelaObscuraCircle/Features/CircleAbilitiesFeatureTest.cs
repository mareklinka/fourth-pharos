using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleAbilitiesFeatureTest
{
    [Fact]
    public void DefaultAbilityLimitTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<CircleAbilitiesFeature>()
            .MaximumAbilities
            .ShouldBe(1);

    [Fact]
    public void DefaultAvailableAbilityTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<CircleAbilitiesFeature>()
            .AvailableAbilities
            .ShouldBe(1);

    [Fact]
    public void AddingAbilityDecreasesAvailableAbilities() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .GetFeature<CircleAbilitiesFeature>()
            .AvailableAbilities
            .ShouldBe(0);
}
