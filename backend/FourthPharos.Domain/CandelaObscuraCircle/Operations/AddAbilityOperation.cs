using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class AddAbilityOperation
{
    public static Circle AddAbility(this Circle circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<CircleAbilitiesFeature>();

        if (feature.Abilities.Contains(ability))
        {
            throw DomainExceptions.CircleExceptions.AbilityAlreadyExists(ability.Code);
        }

        if (feature.AvailableAbilities == 0)
        {
            throw DomainExceptions.CircleExceptions.AbilityLimitReached();
        }

        circle = ability.OnAdded?.Invoke(circle) ?? circle;

        return circle.UpdateFeature(feature with { Abilities = feature.Abilities.Add(ability) });
    }
}
