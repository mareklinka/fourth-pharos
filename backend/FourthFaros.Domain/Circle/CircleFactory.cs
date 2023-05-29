using System.Collections.Immutable;
using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle;

public static class CircleFactory
{
    public static CircleBase CreateCirle(string name, CircleAbility ability, string? location = null)
    {
        CircleValidators.Name(name);
        CircleValidators.Location(location);

        return new(name, location) { Abilities = ImmutableArray.Create(ability) };
    }
}
