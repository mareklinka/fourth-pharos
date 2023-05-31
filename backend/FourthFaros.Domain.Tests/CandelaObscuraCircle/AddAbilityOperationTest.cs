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
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.StaminaTraining);

        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        feature.Abilities.Length.ShouldBe(2);
        feature.Abilities.ShouldContain(CircleAbility.ForgedInFire);
        feature.Abilities.ShouldContain(CircleAbility.StaminaTraining);
        circle.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void AddExistingAbilityFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.ForgedInFire));
    }
}
