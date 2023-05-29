using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class AddAbilityOperationTest
{
    [Fact]
    public void AddAbility()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.StaminaTraining);

        circle.Abilities.Length.ShouldBe(2);
        circle.Abilities.ShouldContain(CircleAbility.ForgedInFire);
        circle.Abilities.ShouldContain(CircleAbility.StaminaTraining);
        circle.StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.ForgedInFire));
    }
}
