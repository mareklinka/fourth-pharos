using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
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
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void RemoveNonExistingGear() =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddGear("Lanterna Obscura")
            .RemoveGear("A Magickal Doodad")
            .Gear
            .ShouldHaveSingleItem()
            .Name
            .ShouldBe("Lanterna Obscura");
}
