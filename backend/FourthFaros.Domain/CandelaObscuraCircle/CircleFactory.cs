using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle;

public static class CircleFactory
{
    public static Circle CreateCirle(string name, CircleAbility ability)
    {
        CircleValidators.Name(name);

        return new Circle()
            .AddFeature(t => new CircleNameFeature(t, name))
            .AddFeature(t => new CircleLocationFeature(t))
            .AddFeature(t => new CircleAbilitiesFeature(t))
            .AddFeature(t => new CircleIlluminationFeature(t))
            .AddFeature(t => new CircleGearFeature(t))
            .AddFeature(t => new CircleResourcesFeature(t))
            .AddAbility(ability);
    }
}
