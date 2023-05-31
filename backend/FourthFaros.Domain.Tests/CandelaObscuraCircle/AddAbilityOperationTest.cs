using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class AddAbilityOperationTest
{
    [Fact]
    public void AddAbility()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire);
    }

    [Fact]
    public void StaminaTraininghooksUpFeatureTest()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.StaminaTraining);
        circle.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
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
