using FourthFaros.Domain.Circle.Models;

namespace FourthFaros.Domain;

public static class DomainExceptions
{
    public static class CircleExceptions
    {
        public static DomainActionException CircleNameEmpty() => new(nameof(CircleNameEmpty), "The circle name must not be empty");

        public static DomainActionException CircleNameTooLong(int length) => new(nameof(CircleNameTooLong), $"The circle name must not exceed {length} characters", length);

        public static DomainActionException CircleLocationTooLong(int length) => new(nameof(CircleLocationTooLong), $"The circle's location must not exceed {length} characters", length);

        public static DomainActionException NotEnoughResource(CircleResource resource) => new(nameof(NotEnoughResource), "The circle doesn't have enough resource to spend", resource);

        public static DomainActionException ResourceFull(CircleResource resource) => new(nameof(ResourceFull), "The circle's resource is at maximum", resource);

        public static DomainActionException AbilityAlreadyExists(string abilityCode) => new(nameof(ResourceFull), "The circle already has this ability", abilityCode);

        public static DomainActionException NotEnoughStaminaDice() => new(nameof(NotEnoughStaminaDice), "The circle doesn't have enough stamina dice to spend");

        public static DomainActionException StaminaDiceFull() => new(nameof(StaminaDiceFull), "The circle's stamina dice are at maximum");

        public static DomainActionException IlluminationBelowZero() => new(nameof(IlluminationBelowZero), "Illumination cannot be less than 0");
    }

    public static class CircleGearExceptions
    {
        public static DomainActionException GearNameEmpty() => new(nameof(GearNameEmpty), "The gear name must not be empty");

        public static DomainActionException GearNameTooLong(int length) => new(nameof(GearNameTooLong), $"The gear name must not exceed {length} characters", length);
    }

    public static class FeatureExceptions
    {
        public static DomainActionException FeatureNotAttached(string featureName) =>
            new(nameof(FeatureNotAttached), $"The feature {featureName} is not available");
    }
}
