using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class RemoveAbilityOperation
{
    public static Circle RemoveAbility(this Circle circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<CircleAbilitiesFeature>();

        circle = ability.OnRemoved?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Remove(ability) });
    }
}
