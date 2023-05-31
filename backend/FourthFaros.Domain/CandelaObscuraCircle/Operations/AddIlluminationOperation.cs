using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class AddIlluminationOperation
{
    public static Circle AddIllumination(this Circle circle, int illumination)
    {
        var feature = circle.GetFeature<Circle, CircleIlluminationFeature>();

        if (feature.Illumination + illumination < 0)
        {
            DomainExceptions.CircleExceptions.IlluminationBelowZero();
        }

        feature = feature with { Illumination = feature.Illumination + illumination };

        return circle.UpdateFeature(feature);
    }
}
