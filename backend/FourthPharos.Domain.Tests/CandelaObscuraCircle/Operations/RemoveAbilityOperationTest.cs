using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class RemoveAbilityOperationTest
{
    [Fact]
    public void RemoveAbility() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .RemoveAbility(CircleAbility.ForgedInFire)
            .GetFeature<CircleAbilitiesFeature>()
            .Abilities
            .Length
            .ShouldBe(0);

    [Fact]
    public void RemoveNonExistingAbilityNoopTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .RemoveAbility(CircleAbility.StaminaTraining)
            .GetFeature<CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .Code
            .ShouldBe(CircleAbility.ForgedInFire.Code);

    [Fact]
    public void StaminaTrainingUnhooksFeatureTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining)
            .RemoveAbility(CircleAbility.StaminaTraining)
            .TryGetFeature<StaminaTrainingFeature>().ShouldBeNull();
}
