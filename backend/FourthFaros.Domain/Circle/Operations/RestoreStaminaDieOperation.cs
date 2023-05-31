using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class RestoreStaminaDieOperation
{
    public static CircleBase RestoreStaminaDice(this CircleBase circle)
    {
        var feature = circle.GetFeature<CircleBase, StaminaTrainingFeature>();

        return feature.StaminaDice == 3
            ? throw DomainExceptions.CircleExceptions.StaminaDiceFull()
            : circle.UpdateFeature(feature with { StaminaDice = feature.StaminaDice + 1 });
    }
}
