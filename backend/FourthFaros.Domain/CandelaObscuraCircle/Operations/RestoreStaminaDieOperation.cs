using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

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
