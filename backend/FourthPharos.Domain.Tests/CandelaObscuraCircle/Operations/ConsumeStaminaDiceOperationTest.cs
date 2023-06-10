using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class ConsumeStaminaDiceOperationTest
{
    [Fact]
    public void ConsumeStaminaDie() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .SelectAbility(CircleAbility.StaminaTraining.Code, 1)
            .ConsumeStaminaDice()
            .GetFeature<Circle, StaminaTrainingFeature>()
            .StaminaDice
            .ShouldBe(2);

    [Fact]
    public void NotEnoughStaminaDice() =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle")
                .SelectAbility(CircleAbility.StaminaTraining.Code, 1)
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NotEnoughStaminaDice));
}
