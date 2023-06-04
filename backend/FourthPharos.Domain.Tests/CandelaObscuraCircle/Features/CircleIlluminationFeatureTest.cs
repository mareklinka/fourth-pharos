using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

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

    [Fact]
    public void PersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(10)
            .GetFeature<Circle, CircleIlluminationFeature>();

        var json = JToken.FromObject(feature.GetData()!);

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Illumination.ShouldBe(deserialized.Illumination);
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}
