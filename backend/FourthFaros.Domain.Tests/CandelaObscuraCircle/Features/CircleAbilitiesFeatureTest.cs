using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle.Features;

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
}
