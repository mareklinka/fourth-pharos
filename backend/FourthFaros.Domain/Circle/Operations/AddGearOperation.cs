using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddGearOperation
{
    public static CircleBase AddGear(this CircleBase circle, string gearName)
    {
        var feature = circle.GetFeature<CircleBase, CircleGearFeature>();

        CircleGearValidators.Name(gearName);

        return circle.UpdateFeature(feature with { Gear = feature.Gear.Add(new(gearName)) });
    }
}
