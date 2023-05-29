using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class RemoveGearOperation
{
    public static CircleBase RemoveGear(this CircleBase circle, string gearName)
    {
        var item = circle.Gear.FirstOrDefault(_ => _.Name == gearName);

        return item switch
        {
            null => circle,
            _ => circle with { Gear = circle.Gear.Remove(item) }
        };
    }
}
