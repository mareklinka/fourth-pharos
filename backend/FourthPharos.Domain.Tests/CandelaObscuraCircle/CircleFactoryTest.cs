using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle;

public class CircleFactoryTest
{
    [Fact]
    public void EmptyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle(string.Empty))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void WhitespaceOnlyNameFails()
    {
        Should
            .Throw<DomainActionException>(() => CircleFactory.CreateCirle(" \t"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameEmpty));
    }

    [Fact]
    public void NameMustNotExceedMaxLength()
    {
        var ex = Should.Throw<DomainActionException>(() => CircleFactory.CreateCirle(new string('a', CircleValidators.NameMaxLength + 1)));
        ex.Code.ShouldBe(nameof(DomainExceptions.CircleExceptions.CircleNameTooLong));
        ex.GetParameters().ShouldHaveSingleItem().ShouldBeOfType<int>().ShouldBe(CircleValidators.NameMaxLength);
    }

    [Fact]
    public void NewCircleHasCorrectFeatures() =>
        Should.NotThrow(() =>
        {
            var circle = CircleFactory.CreateCirle("Test circle");

            circle.Features.Count.ShouldBe(6);

            circle.GetFeature<CircleNameFeature>();
            circle.GetFeature<CircleLocationFeature>();
            circle.GetFeature<CircleGearFeature>();
            circle.GetFeature<CircleAbilitiesFeature>();
            circle.GetFeature<CircleResourcesFeature>();
            circle.GetFeature<CircleIlluminationFeature>();
        });

    [Fact]
    public void NewCircleWithoutLocation() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleLocationFeature>()
            .Location
            .ShouldBeNull();

    [Fact]
    public void NewCircleHasZeroIllumination() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(0);

    [Fact]
    public void NewCircleHasZeroMilestone() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleIlluminationFeature>()
            .Milestone
            .ShouldBe(CircleMilestone.None);

    [Fact]
    public void NewCircleHasNoGear() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void NewCircleHasNoCharacters() =>
        CircleFactory.CreateCirle("Test circle").Characters.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasOneOfEachResourceMax() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleResourcesFeature>()
            .ResourceMaximum
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NewCircleHasOneOfEachResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Fact]
    public void NewCircleIsFirstRank() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<CircleIlluminationFeature>()
            .Rank
            .ShouldBe(1);
}
