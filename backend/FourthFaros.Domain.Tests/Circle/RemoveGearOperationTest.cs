using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class RemoveGearOperationTest
{
    [Fact]
    public void RemoveExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddGear("Lanterna Obscura")
            .RemoveGear("Lanterna Obscura")
            .GetFeature<CircleBase, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void RemoveNonExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddGear("Lanterna Obscura")
            .RemoveGear("A Magickal Doodad")
            .GetFeature<CircleBase, CircleGearFeature>()
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");
}
