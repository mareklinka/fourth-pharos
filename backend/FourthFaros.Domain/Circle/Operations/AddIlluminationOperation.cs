using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddIlluminationOperation
{
    public static CircleBase AddIllumination(this CircleBase circle, int illumination)
    {
        var feature = circle.GetFeature<CircleBase, CircleIlluminationFeature>();

        if (feature.Illumination + illumination < 0)
        {
            DomainExceptions.CircleExceptions.IlluminationBelowZero();
        }

        feature = feature with { Illumination = feature.Illumination + illumination };

        return circle.UpdateFeature(feature);
    }
}
