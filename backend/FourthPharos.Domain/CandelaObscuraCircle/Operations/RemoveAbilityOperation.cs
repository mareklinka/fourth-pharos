using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class RemoveAbilityOperation
{
    public static Circle RemoveAbility(this Circle circle, string abilityCode)
    {
        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

        var ability = feature.Abilities.FirstOrDefault(_ => _.Code == abilityCode);

        if (ability is null)
        {
            return circle;
        }

        circle = ability.OnRemoved?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Remove(ability) });
    }
}
