using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class AddIlluminationOperationTest
{
    [Theory]
    [MemberData(nameof(IlluminationData))]
    public void AddOneIllumination(int illumination)
    {
        CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(illumination)
            .GetFeature<CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(illumination);
    }

    public static IEnumerable<object[]> IlluminationData => Enumerable.Range(1, 100).Select(_ => new object[] { _ });
}
