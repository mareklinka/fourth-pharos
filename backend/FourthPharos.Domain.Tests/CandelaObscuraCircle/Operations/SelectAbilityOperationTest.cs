using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class SelectAbilityOperationTest
{
    [Fact]
    public void SelectAbility()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.ForgedInFire.Code, 1);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire with { TakenAtRank = 1 });
    }

    [Fact]
    public void StaminaTrainingHooksUpFeatureTest()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.StaminaTraining.Code, 1);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.StaminaTraining with { TakenAtRank = 1 });
        circle.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void AddInvalidAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility("ab1", 1))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.InvalidAbility));
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(24)
            .SelectAbility(CircleAbility.ForgedInFire.Code, 1)
            .SelectAbility(CircleAbility.ForgedInFire.Code, 2))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityAlreadyExists));
    }

    [Fact]
    public void AbilityReplacementTest()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.ForgedInFire.Code, 1)
            .SelectAbility(CircleAbility.Interdisciplinary.Code, 1);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.Interdisciplinary with { TakenAtRank = 1 });

    }

    [Fact]
    public void AddAbilityOverCurrentRankFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.ForgedInFire.Code, 2))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.InsufficientRank));
    }

    [Fact]
    public void RemoveAbility() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(null, 1)
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .Abilities
            .Length
            .ShouldBe(0);

    [Fact]
    public void StaminaTrainingUnhooksFeatureTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.StaminaTraining.Code, 1)
            .SelectAbility(null, 1)
            .TryGetFeature<Circle, StaminaTrainingFeature>().ShouldBeNull();
}
