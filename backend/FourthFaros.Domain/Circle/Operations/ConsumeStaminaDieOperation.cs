using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class ConsumeStaminaDieOperation
{
    public static CircleBase ConsumeStaminaDice(this CircleBase circle)
    {
        return circle.StaminaDice switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughStaminaDice(),
            int amount => circle with { StaminaDice = amount - 1 }
        };
    }
}
