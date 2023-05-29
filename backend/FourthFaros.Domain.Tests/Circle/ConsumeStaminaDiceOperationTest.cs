using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class ConsumeStaminaDiceOperationTest
{
    [Fact]
    public void ConsumeStaminaDie() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.StaminaTraining)
            .ConsumeStaminaDice()
            .StaminaDice
            .ShouldBe(2);

    [Fact]
    public void NotEnoughStaminaDice() =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle", CircleAbility.StaminaTraining)
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice()
                .ConsumeStaminaDice())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NotEnoughStaminaDice));
}
