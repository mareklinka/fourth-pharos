using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class SetLocationOperationTest
{
    [Fact]
    public void UpdateLocation() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .SetName("New Name")
            .Name
            .ShouldBe("New Name");

    [Fact]
    public void EmptyNameFails()
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire);

        Should
            .Throw<DomainActionException>(() => circle.SetName(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire);

        Should
            .Throw<DomainActionException>(() => circle.SetName(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire);

        var ex = Should.Throw<DomainActionException>(() => circle.SetName(new string('a', CircleValidators.NameMaxLength + 1)));

        ex.Code.ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }
}
