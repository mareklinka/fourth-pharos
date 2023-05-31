using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class RemoveAbilityOperation
{
    public static Circle RemoveAbility(this Circle circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        circle = ability.OnRemoved?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Remove(ability) });
    }
}
