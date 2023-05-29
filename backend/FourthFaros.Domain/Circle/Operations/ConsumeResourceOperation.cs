using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class ConsumeResourceOperation
{
    public static CircleBase ConsumeResource(this CircleBase circle, CircleResource resource)
    {
        return circle.Resources[resource] switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughResource(resource),
            int amount => circle with { Resources = circle.Resources.SetItem(resource, amount - 1) }
        };
    }
}
