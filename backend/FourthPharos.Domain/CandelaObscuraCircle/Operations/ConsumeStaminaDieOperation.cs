using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

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
