using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class RestoreStaminaDiceOperationTest
{
    [Fact]
    public void RestoreStaminaDie() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining)
            .ConsumeStaminaDice()
            .RestoreStaminaDice()
            .GetFeature<Circle, StaminaTrainingFeature>()
            .StaminaDice
            .ShouldBe(3);

    [Fact]
    public void RestoreFullStaminaDice() =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle")
                .AddAbility(CircleAbility.StaminaTraining)
                .RestoreStaminaDice())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.StaminaDiceFull));
}
