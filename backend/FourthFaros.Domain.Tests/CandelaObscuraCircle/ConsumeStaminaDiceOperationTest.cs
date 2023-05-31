using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class ConsumeStaminaDiceOperationTest
{
    [Fact]
    public void ConsumeStaminaDie() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining)
            .ConsumeStaminaDice()
            .GetFeature<Circle, StaminaTrainingFeature>()
            .StaminaDice
            .ShouldBe(2);

    [Fact]
    public void NotEnoughStaminaDice() =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle")
                .AddAbility(CircleAbility.StaminaTraining)
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NotEnoughStaminaDice));
}
