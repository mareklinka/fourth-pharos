using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Features;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
using FourthFaros.Domain.Features;
using Shouldly;

namespace FourthFaros.Domain.Tests.Circle;

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
            .GetFeature<CircleBase, CircleResourcesFeature>()
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
