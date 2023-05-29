using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class SetLocationOperation
{
    public static CircleBase SetLocation(this CircleBase circle, string location)
    {
        CircleValidators.Location(location);

        return circle with { Location = location };
    }
}
