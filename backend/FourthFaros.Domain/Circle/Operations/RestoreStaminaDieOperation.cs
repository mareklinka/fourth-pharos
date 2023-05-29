using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class RestoreStaminaDieOperation
{
    public static CircleBase RestoreStaminaDice(this CircleBase circle)
    {
        return circle.StaminaDice == 3
            ? throw DomainExceptions.CircleExceptions.StaminaDiceFull()
            : (circle with { StaminaDice = circle.StaminaDice + 1 });
    }
}
