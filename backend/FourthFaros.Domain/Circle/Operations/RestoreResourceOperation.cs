using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class RestoreResourceOperation
{
    public static CircleBase RestoreResource(this CircleBase circle, CircleResource resource)
    {
        var feature = circle.GetFeature<CircleBase, CircleResourcesFeature>();

        var current = feature.Resources[resource];

        return current == feature.ResourceMaximum
            ? throw DomainExceptions.CircleExceptions.ResourceFull(resource)
            : circle.UpdateFeature(feature with { Resources = feature.Resources.SetItem(resource, current + 1) });
    }
}
