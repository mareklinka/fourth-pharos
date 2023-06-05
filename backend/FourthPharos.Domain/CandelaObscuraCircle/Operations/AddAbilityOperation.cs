using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class AddAbilityOperation
{
    public static Circle AddAbility(this Circle circle, string abilityCode, int takenAtRank)
    {
        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();
        var illuminationFeature = circle.GetFeature<Circle, CircleIlluminationFeature>();

        var ability = Validate(abilityCode, takenAtRank, feature, illuminationFeature);

        if (ability.Code == CircleAbility.StaminaTraining.Code)
        {
            circle = circle.AddFeature(t => new StaminaTrainingFeature(t));
        }

        return circle.UpdateFeature(feature with
        {
            Abilities = feature.Abilities.Add(ability with { TakenAtRank = takenAtRank })
        });
    }

    private static CircleAbility Validate(
        string abilityCode,
        int takenAtRank,
        CircleAbilitiesFeature abilitiesFeature,
        CircleIlluminationFeature illuminationFeature)
    {
        if (abilitiesFeature.AvailableAbilities == 0)
        {
            throw DomainExceptions.CircleExceptions.AbilityLimitReached();
        }

        if (abilitiesFeature.Abilities.Any(_ => _.Code == abilityCode))
        {
            throw DomainExceptions.CircleExceptions.AbilityAlreadyExists(abilityCode);
        }

        if (abilitiesFeature.Abilities.Any(_ => _.TakenAtRank == takenAtRank))
        {
            throw DomainExceptions.CircleExceptions.AbilityForRankExists(takenAtRank);
        }

        if (illuminationFeature.Rank < takenAtRank)
        {
            throw DomainExceptions.CircleExceptions.InsufficientRank(takenAtRank);
        }

        if (!CircleAbility.Abilities.TryGetValue(abilityCode, out var ability))
        {
            throw DomainExceptions.CircleExceptions.InvalidAbility(abilityCode);
        }

        return ability;
    }
}
