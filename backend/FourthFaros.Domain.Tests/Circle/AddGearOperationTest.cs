using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class AddGearOperationTest
{
    [Fact]
    public void AddGear() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddGear("Lanterna Obscura")
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
