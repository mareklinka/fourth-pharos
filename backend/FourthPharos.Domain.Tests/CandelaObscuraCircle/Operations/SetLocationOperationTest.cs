using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class SetLocationOperationTest
{
    [Fact]
    public void UpdateLocation() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .SetName("New Name")
            .GetFeature<Circle, CircleNameFeature>()
            .Name
            .ShouldBe("New Name");

    [Fact]
    public void EmptyNameFails()
    {
        var circle = CircleFactory.CreateCirle("Test Circle");

        Should
            .Throw<DomainActionException>(() => circle.SetName(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        var circle = CircleFactory.CreateCirle("Test Circle");

        Should
            .Throw<DomainActionException>(() => circle.SetName(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var circle = CircleFactory.CreateCirle("Test Circle");

        var ex = Should.Throw<DomainActionException>(() => circle.SetName(new string('a', CircleValidators.NameMaxLength + 1)));

        ex.Code.ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }
}
