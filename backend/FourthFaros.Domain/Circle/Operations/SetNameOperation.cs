using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class SetNameOperation
{
    public static CircleBase SetName(this CircleBase circle, string name)
    {
        CircleValidators.Name(name);

        return circle with { Name = name };
    }
}
