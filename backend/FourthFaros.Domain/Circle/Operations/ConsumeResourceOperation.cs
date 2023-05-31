using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class ConsumeResourceOperation
{
    public static CircleBase ConsumeResource(this CircleBase circle, CircleResource resource)
    {
        var feature = circle.GetFeature<CircleBase, CircleResourcesFeature>();

        return feature.Resources[resource] switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughResource(resource),
            int current => circle.UpdateFeature(feature with { Resources = feature.Resources.SetItem(resource, current - 1) })
        };
    }
}
