using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class RemoveGearOperationTest
{
    [Fact]
    public void RemoveExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .RemoveGear("Lanterna Obscura")
            .GetFeature<CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void RemoveNonExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Lanterna Obscura")
            .RemoveGear("A Magickal Doodad")
            .GetFeature<CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");
}
