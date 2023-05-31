using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class SetLocationOperation
{
    public static CircleBase SetLocation(this CircleBase circle, string location)
    {
        var feature = circle.GetFeature<CircleBase, CircleLocationFeature>();

        CircleValidators.Location(location);

        return circle.UpdateFeature(feature with { Location = location });
    }
}
