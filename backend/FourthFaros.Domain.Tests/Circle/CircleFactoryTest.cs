using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

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
            .GetFeature<CircleBase, CircleLocationFeature>()
            .Location
            .ShouldBeNull();

    [Fact]
    public void NewCircleWithLocation() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .SetLocation("Haunted Street 1")
            .GetFeature<CircleBase, CircleLocationFeature>()
            .Location
            .ShouldBe("Haunted Street 1");

    [Fact]
    public void NewCircleHasZeroIllumination() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(0);

    [Fact]
    public void NewCircleHasZeroMilestone() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleIlluminationFeature>()
            .Milestone
            .ShouldBe(CircleMilestone.None);

    [Fact]
    public void NewCircleHasNoGear() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void NewCircleHasNoCharacters() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Characters.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasOneOfEachResourceMax() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleResourcesFeature>()
            .ResourceMaximum
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NewCircleHasOneOfEachResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Fact]
    public void NewCircleHasDeclaredAbility() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .ShouldBe(CircleAbility.ForgedInFire);

    [Fact]
    public void NewCircleWithStaminaTrainingHasGildenDice()
    {
        var circle = CircleFactory.CreateCirle("Test circle", CircleAbility.StaminaTraining);

        circle
            .GetFeature<CircleBase, CircleAbilitiesFeature>()
            .Abilities
            .ShouldHaveSingleItem()
            .ShouldBe(CircleAbility.StaminaTraining);
        circle.GetFeature<CircleBase, StaminaTrainingFeature>().StaminaDice.ShouldBe(3);
    }

    [Fact]
    public void NewCircleIsFirstLevel() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .GetFeature<CircleBase, CircleIlluminationFeature>()
            .Rank
            .ShouldBe(1);
}
