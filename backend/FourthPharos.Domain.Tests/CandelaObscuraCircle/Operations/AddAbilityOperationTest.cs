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
            .AddAbility(CircleAbility.ForgedInFire.Code, 1);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.ShouldHaveSingleItem();
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire with { TakenAtRank = 1 });
    }

    [Fact]
    public void StaminaTrainingHooksUpFeatureTest()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining.Code, 1);

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
            .AddAbility("ab1", 1))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.InvalidAbility));
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(24)
            .AddAbility(CircleAbility.ForgedInFire.Code, 1)
            .AddAbility(CircleAbility.ForgedInFire.Code, 2))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityAlreadyExists));
    }

    [Fact]
    public void AbilityLimitTest()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire.Code, 1)
            .AddAbility(CircleAbility.Interdisciplinary.Code, 1))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityLimitReached));
    }

    [Fact]
    public void AddAbilityOfExistingRankFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(24)
            .AddAbility(CircleAbility.ForgedInFire.Code, 1)
            .AddAbility(CircleAbility.StaminaTraining.Code, 1))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.AbilityForRankExists));
    }

    [Fact]
    public void AddAbilityOverCurrentRankFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire.Code, 2))
        .Code
        .ShouldBe(nameof(DomainExceptions.CircleExceptions.InsufficientRank));
    }
}
