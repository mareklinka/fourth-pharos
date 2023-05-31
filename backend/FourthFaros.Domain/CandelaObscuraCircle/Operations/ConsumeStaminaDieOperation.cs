using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class ConsumeStaminaDieOperation
{
    public static Circle ConsumeStaminaDice(this Circle circle)
    {
        var feature = circle.GetFeature<Circle, StaminaTrainingFeature>();
        return feature.StaminaDice switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughStaminaDice(),
            int => circle.UpdateFeature(feature with { StaminaDice = feature.StaminaDice - 1 })
        };
    }
}
