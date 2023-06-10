using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class SelectAbilityOperation
{
    public static Circle SelectAbility(this Circle circle, string? abilityCode, int takenAtRank)
    {
        var feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();
        var illuminationFeature = circle.GetFeature<Circle, CircleIlluminationFeature>();

        var (newAbility, existingAbility) = Validate(abilityCode, takenAtRank, feature, illuminationFeature);

        if (newAbility?.Code == CircleAbility.StaminaTraining.Code)
        {
            circle = circle.AddFeature(t => new StaminaTrainingFeature(t));
        }

        if (existingAbility?.Code == CircleAbility.StaminaTraining.Code)
        {
            circle = circle.RemoveFeature<Circle, StaminaTrainingFeature>();
        }

        if (existingAbility is not null)
        {
            circle = circle.UpdateFeature(feature with { Abilities = feature.Abilities.Remove(existingAbility) });
            feature = circle.GetFeature<Circle, CircleAbilitiesFeature>();
        }

        if (newAbility is not null)
        {
            circle = circle.UpdateFeature(feature with { Abilities = feature.Abilities.Add(newAbility with { TakenAtRank = takenAtRank }) });
        }

        return circle;
    }

    private static (CircleAbility? New, CircleAbility? Existing) Validate(
        string? abilityCode,
        int takenAtRank,
        CircleAbilitiesFeature abilitiesFeature,
        CircleIlluminationFeature illuminationFeature)
    {
        var existingAbility = abilitiesFeature.Abilities.FirstOrDefault(_ => _.TakenAtRank == takenAtRank);

        if (abilityCode is null)
        {
            return (null, existingAbility);
        }

        if (existingAbility is null && abilitiesFeature.AvailableAbilities == 0)
        {
            throw DomainExceptions.CircleExceptions.AbilityLimitReached();
        }

        if (abilitiesFeature.Abilities.Any(_ => _.Code == abilityCode))
        {
            throw DomainExceptions.CircleExceptions.AbilityAlreadyExists(abilityCode);
        }

        if (illuminationFeature.Rank < takenAtRank)
        {
            throw DomainExceptions.CircleExceptions.InsufficientRank(takenAtRank);
        }

        if (!CircleAbility.Abilities.TryGetValue(abilityCode, out var ability))
        {
            throw DomainExceptions.CircleExceptions.InvalidAbility(abilityCode);
        }

        return (ability, existingAbility);
    }
}