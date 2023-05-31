using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class ConsumeResourceOperation
{
    public static Circle ConsumeResource(this Circle circle, CircleResource resource)
    {
        var feature = circle.GetFeature<Circle, CircleResourcesFeature>();

        return feature.Resources[resource] switch
        {
            < 1 => throw DomainExceptions.CircleExceptions.NotEnoughResource(resource),
            int current => circle.UpdateFeature(feature with { Resources = feature.Resources.SetItem(resource, current - 1) })
        };
    }
}
