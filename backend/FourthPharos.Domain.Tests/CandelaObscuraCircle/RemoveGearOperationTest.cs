using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle;

public class RemoveGearOperationTest
{
    [Fact]
    public void RemoveExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .RemoveGear("Lanterna Obscura")
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void RemoveNonExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .RemoveGear("A Magickal Doodad")
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");
}
