using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class RestoreStaminaDieOperation
{
    public static Circle RestoreStaminaDice(this Circle circle)
    {
        var feature = circle.GetFeature<Circle, StaminaTrainingFeature>();

        return feature.StaminaDice == 3
            ? throw DomainExceptions.CircleExceptions.StaminaDiceFull()
            : circle.UpdateFeature(feature with { StaminaDice = feature.StaminaDice + 1 });
    }
}
