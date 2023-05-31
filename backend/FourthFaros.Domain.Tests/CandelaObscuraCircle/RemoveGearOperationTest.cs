using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

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
