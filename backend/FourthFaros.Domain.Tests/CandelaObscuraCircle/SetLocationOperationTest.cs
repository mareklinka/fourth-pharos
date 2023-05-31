using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class SetLocationOperationTest
{
    [Fact]
    public void UpdateLocation() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .SetName("New Name")
            .GetFeature<Circle, CircleNameFeature>()
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
