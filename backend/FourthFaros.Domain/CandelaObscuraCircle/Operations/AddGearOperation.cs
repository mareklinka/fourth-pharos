using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class AddGearOperation
{
    public static Circle AddGear(this Circle circle, string gearName)
    {
        var feature = circle.GetFeature<Circle, CircleGearFeature>();

        CircleGearValidators.Name(gearName);

        return circle.UpdateFeature(feature with { Gear = feature.Gear.Add(new(gearName)) });
    }
}
