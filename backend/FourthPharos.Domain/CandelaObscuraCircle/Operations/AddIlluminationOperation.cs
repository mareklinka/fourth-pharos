using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class AddIlluminationOperation
{
    public static Circle AddIllumination(this Circle circle, int illumination)
    {
        var feature = circle.GetFeature<CircleIlluminationFeature>();

        if (feature.Illumination + illumination < 0)
        {
            DomainExceptions.CircleExceptions.IlluminationBelowZero();
        }

        feature = feature with { Illumination = feature.Illumination + illumination };

        return circle.UpdateFeature(feature);
    }
}
