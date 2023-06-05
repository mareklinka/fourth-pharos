using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class AddAbilityOperationTest
{
    [Fact]
    public void AddAbility()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire);

        var feature = circle.GetFeature<CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire);
    }

    [Fact]
    public void StaminaTrainingHooksUpFeatureTest()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining);

        var feature = circle.GetFeature<CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.StaminaTraining);
        circle.GetFeature<StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.ForgedInFire))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityAlreadyExists));
    }

    [Fact]
    public void AbilityLimitTest()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.Interdisciplinary))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityLimitReached));
    }
}
