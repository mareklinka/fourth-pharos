using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain.Circle.Operations;

public static class RemoveAbilityOperation
{
    public static CircleBase RemoveAbility(this CircleBase circle, CircleAbility ability)
    {
        if (ability == CircleAbility.StaminaTraining)
        {
            circle = circle with { StaminaDice = 0 };
        }

        return circle with { Abilities = circle.Abilities.Remove(ability) };
    }
}
