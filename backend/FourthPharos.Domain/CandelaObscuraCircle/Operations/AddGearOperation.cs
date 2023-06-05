using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class AddGearOperation
{
    public static Circle AddGear(this Circle circle, string gearName)
    {
        var feature = circle.GetFeature<CircleGearFeature>();

        CircleGearValidators.Name(gearName);

        return circle.UpdateFeature(feature with { Gear = feature.Gear.Add(new(gearName)) });
    }
}
