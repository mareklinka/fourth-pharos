using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.CandelaObscuraCircle.Operations;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

public class ConsumeResourceOperationTest
{
    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void ConsumeResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .ConsumeResource(resource)
            .GetFeature<Circle, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(0);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NotEnoughResource(CircleResource resource) =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
                .ConsumeResource(resource)
                .ConsumeResource(resource))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NotEnoughResource));
}
