using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class RestoreResourceOperationTest
{
    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void RestoreResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test Circle")
            .ConsumeResource(resource)
            .RestoreResource(resource)
            .GetFeature<Circle, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void RestoreFullResource(CircleResource resource) =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle")
                .RestoreResource(resource))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.ResourceFull));
}
