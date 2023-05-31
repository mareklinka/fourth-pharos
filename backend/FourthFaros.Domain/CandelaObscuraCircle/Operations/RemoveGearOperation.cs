using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class RemoveGearOperation
{
    public static Circle RemoveGear(this Circle circle, string gearName)
    {
        var feature = circle.GetFeature<Circle, CircleGearFeature>();

        var item = feature.Gear.FirstOrDefault(_ => _.Name == gearName);

        return item switch
        {
            null => circle,
            _ => circle.UpdateFeature(feature with { Gear = feature.Gear.Remove(item) })
        };
    }
}
