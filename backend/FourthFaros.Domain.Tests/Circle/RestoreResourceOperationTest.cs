using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

public class RestoreResourceOperationTest
{
    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void RestoreResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
            .ConsumeResource(resource)
            .RestoreResource(resource)
            .GetFeature<CircleBase, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void RestoreFullResource(CircleResource resource) =>
        Should.Throw<DomainActionException>(() =>
            CircleFactory
                .CreateCirle("Test Circle", CircleAbility.ForgedInFire)
                .RestoreResource(resource))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.ResourceFull));
}
