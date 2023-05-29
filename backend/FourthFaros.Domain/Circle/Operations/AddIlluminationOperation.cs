using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddIlluminationOperation
{
    public static CircleBase AddIllumination(this CircleBase circle, int illumination)
    {
        if (illumination <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(illumination), "Illumination must be >= 0");
        }

        var remainder = (circle.Illumination + illumination) % 24;
        var newRanks = illumination / 24;

        return (newRanks, remainder) switch
        {
            (0, var i) => circle with { Illumination = i },
            (int r, var i) => circle with { Rank = circle.Rank + r, Illumination = i }
        };
    }
}
