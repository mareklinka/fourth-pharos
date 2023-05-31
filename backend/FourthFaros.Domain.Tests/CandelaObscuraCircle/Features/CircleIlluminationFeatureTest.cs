using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleIlluminationFeatureTest
{
    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void MilestoneTest(int illumination)
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(illumination)
            .GetFeature<Circle, CircleIlluminationFeature>();

        feature.Illumination.ShouldBe(illumination);
        feature.Milestone.ShouldBe((CircleMilestone)(illumination % 24 / 7));
    }

    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void RankTest(int illuminationToAdd)
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(illuminationToAdd)
            .GetFeature<Circle, CircleIlluminationFeature>();

        feature.Illumination.ShouldBe(illuminationToAdd);
        feature.Rank.ShouldBe(1 + (illuminationToAdd / 24));
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}
