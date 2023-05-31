using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle;

public static class CircleFactory
{
    public static CircleBase CreateCirle(string name, CircleAbility ability)
    {
        CircleValidators.Name(name);

        return new CircleBase()
            .AddFeature(t => new CircleNameFeature(t, name))
            .AddFeature(t => new CircleLocationFeature(t))
            .AddFeature(t => new CircleAbilitiesFeature(t))
            .AddFeature(t => new CircleIlluminationFeature(t))
            .AddFeature(t => new CircleGearFeature(t))
            .AddFeature(t => new CircleResourcesFeature(t))
            .AddAbility(ability);
    }
}
