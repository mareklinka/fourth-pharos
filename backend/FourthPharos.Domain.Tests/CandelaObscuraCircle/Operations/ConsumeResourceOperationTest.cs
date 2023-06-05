using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class ConsumeResourceOperationTest
{
    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void ConsumeResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test Circle")
            .ConsumeResource(resource)
            .GetFeature<CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(0);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NotEnoughResource(CircleResource resource) =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle")
                .ConsumeResource(resource)
                .ConsumeResource(resource))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NotEnoughResource));
}
