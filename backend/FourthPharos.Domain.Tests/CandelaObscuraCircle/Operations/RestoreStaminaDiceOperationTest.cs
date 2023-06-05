using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class RestoreStaminaDiceOperationTest
{
    [Fact]
    public void RestoreStaminaDie() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining)
            .ConsumeStaminaDice()
            .RestoreStaminaDice()
            .GetFeature<StaminaTrainingFeature>()
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
