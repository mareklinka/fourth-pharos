using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class AddIlluminationOperationTest
{
    [Fact]
    public void AddOneIllumination()
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire);

        circle.AddIllumination(1).Illumination.ShouldBe(1);
    }

    [Theory]
    [InlineData(1, CircleMilestone.None)]
    [InlineData(2, CircleMilestone.None)]
    [InlineData(3, CircleMilestone.None)]
    [InlineData(4, CircleMilestone.None)]
    [InlineData(5, CircleMilestone.None)]
    [InlineData(6, CircleMilestone.None)]
    [InlineData(7, CircleMilestone.First)]
    [InlineData(8, CircleMilestone.First)]
    [InlineData(9, CircleMilestone.First)]
    [InlineData(10, CircleMilestone.First)]
    [InlineData(11, CircleMilestone.First)]
    [InlineData(12, CircleMilestone.First)]
    [InlineData(13, CircleMilestone.First)]
    [InlineData(14, CircleMilestone.Second)]
    [InlineData(15, CircleMilestone.Second)]
    [InlineData(16, CircleMilestone.Second)]
    [InlineData(17, CircleMilestone.Second)]
    [InlineData(18, CircleMilestone.Second)]
    [InlineData(19, CircleMilestone.Second)]
    [InlineData(20, CircleMilestone.Second)]
    [InlineData(21, CircleMilestone.Third)]
    [InlineData(22, CircleMilestone.Third)]
    [InlineData(23, CircleMilestone.Third)]
    public void MilestoneTest(int illuminationToAdd, CircleMilestone expectedMilestone)
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire).AddIllumination(illuminationToAdd);

        circle.Illumination.ShouldBe(illuminationToAdd);
        circle.Milestone.ShouldBe(expectedMilestone);
    }

    [Theory]
    [MemberData(nameof(CarryOverData))]
    public void CarryOverTest(int illuminationToAdd)
    {
        var circle = CircleFactory.CreateCirle("Test Circle", CircleAbility.ForgedInFire).AddIllumination(illuminationToAdd);

        circle.Illumination.ShouldBe(illuminationToAdd % 24);
        circle.Rank.ShouldBe(1 + (illuminationToAdd / 24));
    }

    public static IEnumerable<object[]> CarryOverData => Enumerable.Range(24, 100).Select(_ => new object[] { _ });
}
