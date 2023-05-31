using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle.Features;

public class CircleIlluminationFeatureTest
{
    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void MilestoneTest(int illumination)
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddIllumination(illumination)
            .GetFeature<CircleBase, CircleIlluminationFeature>();

        feature.Illumination.ShouldBe(illumination);
        feature.Milestone.ShouldBe((CircleMilestone)(illumination % 24 / 7));
    }

    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void RankTest(int illuminationToAdd)
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddIllumination(illuminationToAdd)
            .GetFeature<CircleBase, CircleIlluminationFeature>();

        feature.Illumination.ShouldBe(illuminationToAdd);
        feature.Rank.ShouldBe(1 + (illuminationToAdd / 24));
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}