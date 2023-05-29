using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class RemoveAbilityOperationTest
{
    [Fact]
    public void RemoveAbility()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .RemoveAbility(CircleAbility.ForgedInFire);

        circle.Abilities.Length.ShouldBe(0);
    }

    [Fact]
    public void RemoveNonExistingAbilityFails()
    {
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .RemoveAbility(CircleAbility.StaminaTraining)
            .Abilities
            .ShouldHaveSingleItem()
            .Code
            .ShouldBe(CircleAbility.ForgedInFire.Code);
    }
}
