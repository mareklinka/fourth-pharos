using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Operations;

public static class RemoveAbilityOperation
{
    public static CircleBase RemoveAbility(this CircleBase circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<CircleBase, CircleAbilitiesFeature>();

        circle = ability.OnRemoved?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Remove(ability) });
    }
}
