using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class CircleFactoryTest
{
    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle(string.Empty, CircleAbility.ForgedInFire))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle(" \t", CircleAbility.ForgedInFire))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CircleFactory.CreateCirle(new string('a', CircleValidators.NameMaxLength + 1), CircleAbility.ForgedInFire));
        ex.Code.ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }

    [Fact]
    public void NewCircleWithoutLocation() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleLocationFeature>()
            .Location
            .ShouldBeNull();

    [Fact]
    public void NewCircleWithLocation() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .SetLocation("Haunted Street 1")
            .GetFeature<Circle, CircleLocationFeature>()
            .Location
            .ShouldBe("Haunted Street 1");

    [Fact]
    public void NewCircleHasZeroIllumination() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(0);

    [Fact]
    public void NewCircleHasZeroMilestone() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Milestone
            .ShouldBe(CircleMilestone.None);

    [Fact]
    public void NewCircleHasNoGear() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void NewCircleHasNoCharacters() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Characters.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasOneOfEachResourceMax() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleResourcesFeature>()
            .ResourceMaximum
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NewCircleHasOneOfEachResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Fact]
    public void NewCircleHasDeclaredAbility() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .ShouldBe(CircleAbility.ForgedInFire);

    [Fact]
    public void NewCircleWithStaminaTrainingHasGildenDice()
    {
        var circle = CircleFactory.CreateCirle("Test circle", CircleAbility.StaminaTraining);

        circle
            .GetFeature<Circle, CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .ShouldBe(CircleAbility.StaminaTraining);
        circle.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void NewCircleIsFirstLevel() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Rank
            .ShouldBe(1);
}
