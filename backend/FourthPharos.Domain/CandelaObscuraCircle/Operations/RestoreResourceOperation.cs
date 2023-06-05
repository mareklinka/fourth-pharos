using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class RestoreResourceOperation
{
    public static Circle RestoreResource(this Circle circle, CircleResource resource)
    {
        var feature = circle.GetFeature<CircleResourcesFeature>();

        var current = feature.Resources[resource];

        return current == feature.ResourceMaximum
            ? throw DomainExceptions.CircleExceptions.ResourceFull(resource)
            : circle.UpdateFeature(feature with { Resources = feature.Resources.SetItem(resource, current + 1) });
    }
}
