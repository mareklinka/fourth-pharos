using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
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

        var feature = circle.GetFeature<CircleBase, CircleAbilitiesFeature>();

        feature.Abilities.Length.ShouldBe(2);
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire);
        feature.Abilities.ShouldContain(CircleAbility.StaminaTraining);
        circle.GetFeature<CircleBase, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.ForgedInFire));
    }
}
