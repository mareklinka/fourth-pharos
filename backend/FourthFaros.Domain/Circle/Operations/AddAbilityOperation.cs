using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddAbilityOperation
{
    public static CircleBase AddAbility(this CircleBase circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<CircleBase, CircleAbilitiesFeature>();

        if (feature.Abilities.Any(_ => _.Code == ability.Code))
        {
            throw DomainExceptions.CircleExceptions.AbilityAlreadyExists(ability.Code);
        }

        circle = ability.OnAdded?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Add(ability) });
    }
}
