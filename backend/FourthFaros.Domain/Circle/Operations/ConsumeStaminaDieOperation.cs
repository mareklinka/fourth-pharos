using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class ConsumeStaminaDieOperation
{
    public static CircleBase ConsumeStaminaDice(this CircleBase circle)
    {
        var feature = circle.GetFeature<CircleBase, StaminaTrainingFeature>();
        return feature.StaminaDice switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughStaminaDice(),
            int => circle.UpdateFeature(feature with { StaminaDice = feature.StaminaDice - 1 })
        };
    }
}
