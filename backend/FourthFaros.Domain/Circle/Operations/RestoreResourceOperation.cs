using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class RestoreResourceOperation
{
    public static CircleBase RestoreResource(this CircleBase circle, CircleResource resource)
    {
        var current = circle.Resources[resource];

        return current == circle.ResourceMaximum
            ? throw DomainExceptions.CircleExceptions.ResourceFull(resource)
            : (circle with { Resources = circle.Resources.SetItem(resource, current + 1) });
    }
}
