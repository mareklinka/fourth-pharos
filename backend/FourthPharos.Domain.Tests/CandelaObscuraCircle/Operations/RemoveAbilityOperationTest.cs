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
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .Abilities
            .Length
            .ShouldBe(0);

    [Fact]
    public void RemoveNonExistingAbilityNoopTest() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.ForgedInFire)
            .RemoveAbility(CircleAbility.StaminaTraining)
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .Code
            .ShouldBe(CircleAbility.ForgedInFire.Code);
}
