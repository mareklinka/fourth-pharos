using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

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