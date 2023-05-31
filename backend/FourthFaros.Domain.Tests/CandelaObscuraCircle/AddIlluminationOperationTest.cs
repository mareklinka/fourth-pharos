using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class AddIlluminationOperationTest
{
    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void AddOneIllumination(int illumination)
    {
        CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(illumination)
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(illumination);
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}
