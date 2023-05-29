using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddGearOperation
{
    public static CircleBase AddGear(this CircleBase circle, string gearName)
    {
        CircleGearValidators.Name(gearName);

        return circle with { Gear = circle.Gear.Add(new(gearName)) };
    }
}
