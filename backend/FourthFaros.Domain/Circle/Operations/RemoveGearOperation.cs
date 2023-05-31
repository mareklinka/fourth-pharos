using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class RemoveGearOperation
{
    public static CircleBase RemoveGear(this CircleBase circle, string gearName)
    {
        var feature = circle.GetFeature<CircleBase, CircleGearFeature>();

        var item = feature.Gear.FirstOrDefault(_ => _.Name == gearName);

        return item switch
        {
            null => circle,
            _ => circle.UpdateFeature(feature with { Gear = feature.Gear.Remove(item) })
        };
    }
}
