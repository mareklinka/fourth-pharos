using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class AddAbilityOperation
{
    public static Circle AddAbility(this Circle circle, CircleAbility ability)
    {
        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();

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
