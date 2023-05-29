using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;

namespace FourthFaros.Domain.Circle;

public static class CircleFactory
{
    public static CircleBase CreateCirle(string name, CircleAbility ability, string? location = null)
    {
        CircleValidators.Name(name);
        CircleValidators.Location(location);

        return new CircleBase(name, location).AddAbility(ability);
    }
}
