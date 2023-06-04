using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class RemoveGearOperation
{
    public static Circle RemoveGear(this Circle circle, Guid id)
    {
        var feature = circle.GetFeature<Circle, CircleGearFeature>();

        var item = feature.Gear.FirstOrDefault(_ => _.Id == id);

        return item switch
        {
            null => circle,
            _ => circle.UpdateFeature(feature with { Gear = feature.Gear.Remove(item) })
        };
    }
}
