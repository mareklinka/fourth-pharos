using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class SetNameOperation
{
    public static CircleBase SetName(this CircleBase circle, string name)
    {
        var feature = circle.GetFeature<CircleBase, CircleNameFeature>();

        CircleValidators.Name(name);

        return circle.UpdateFeature(feature with { Name = name });
    }
}
