using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class RemoveGearOperationTest
{
    [Fact]
    public void RemoveExistingGear()
    {
        var circle = CircleFactory.CreateCirle("Test Circle");
        var gear = circle
            .AddGear("Lanterna Obscura")
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .Single();

        circle
            .RemoveGear(gear.Id)
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();
    }

    [Fact]
    public void RemoveNonExistingGear() =>
        CircleFactory.CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .RemoveGear(Guid.Empty)
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");
}
