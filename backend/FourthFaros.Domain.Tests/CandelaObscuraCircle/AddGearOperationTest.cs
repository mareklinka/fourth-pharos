using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class AddGearOperationTest
{
    [Fact]
    public void AddGear() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddGear("Lanterna Obscura")
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");

    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire).AddGear(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire).AddGear(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire).AddGear(new string('a', CircleGearValidators.NameMaxLength + 1)));
        ex.Code.ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }
}
