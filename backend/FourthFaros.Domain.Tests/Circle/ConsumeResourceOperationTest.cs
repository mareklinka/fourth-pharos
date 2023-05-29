using FourthFaros.Domain.Circle;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Circle.Operations;
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
