using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
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
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Location.ShouldBeNull();

    [Fact]
    public void NewCircleWithLocation() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire, "Haunted Street 1").Location.ShouldBe("Haunted Street 1");

    [Fact]
    public void LocationMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire, new string('a', CircleValidators.LocationMaxLength + 1)));
        ex.Code.ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleLocationTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.LocationMaxLength);
    }

    [Fact]
    public void NewCircleHasZeroIllumination() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Illumination.ShouldBe(0);

    [Fact]
    public void NewCircleHasZeroMilestone() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Milestone.ShouldBe(CircleMilestone.None);

    [Fact]
    public void NewCircleHasNoGear() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Gear.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasNoCharacters() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Characters.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasOneOfEachResourceMax()
    {
        var circle = CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire);

        circle.StitchMaximum.ShouldBe(1);
        circle.RefreshMaximum.ShouldBe(1);
        circle.TrainMaximum.ShouldBe(1);
    }

    [Fact]
    public void NewCircleHasOneOfEachResource()
    {
        var circle = CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire);

        circle.StitchRemaining.ShouldBe(1);
        circle.RefreshRemaining.ShouldBe(1);
        circle.TrainingRemaining.ShouldBe(1);
    }

    [Fact]
    public void NewCircleHasDeclaredAbility() =>
        CircleFactory
            .CreateCirle("Test circle", CircleAbility.ForgedInFire)
            .Abilities
            .ShouldHaveSingleItem()
            .ShouldBe(CircleAbility.ForgedInFire);

    [Fact]
    public void NewCircleIsFirstLevel() =>
        CircleFactory.CreateCirle("Test circle", CircleAbility.ForgedInFire).Rank.ShouldBe(1);
}
