using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class AddGearOperationTest
{
    [Fact]
    public void AddGear() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .GetFeature<CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");

    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle").AddGear(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle").AddGear(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CircleFactory.CreateCirle("Test Circle").AddGear(new string('a', CircleGearValidators.NameMaxLength + 1)));
        ex.Code.ShouldBe(nameof(DomainExceptions.CircleGearExceptions.GearNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }
}
