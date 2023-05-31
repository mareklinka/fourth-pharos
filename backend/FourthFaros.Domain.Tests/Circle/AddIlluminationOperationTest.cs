using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class AddIlluminationOperationTest
{
    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void AddOneIllumination(int illumination)
    {
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .AddIllumination(illumination)
            .GetFeature<CircleBase, CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(illumination);
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}
