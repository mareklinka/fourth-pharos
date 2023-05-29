using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class AddAbilityOperation
{
    public static CircleBase AddAbility(this CircleBase circle, CircleAbility ability)
    {
        if (circle.Abilities.Any(_ => _.Code == ability.Code))
        {
            throw DomainExceptions.CircleExceptions.AbilityAlreadyExists(ability.Code);
        }

        if (ability == CircleAbility.StaminaTraining)
        {
            circle = circle with { StaminaDice = 3 };
        }

        return circle with { Abilities = circle.Abilities.Add(ability) };
    }
}
