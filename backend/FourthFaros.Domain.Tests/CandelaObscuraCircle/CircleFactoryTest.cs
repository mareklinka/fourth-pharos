using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Tests.CandelaObscuraCircle;

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

            circle.GetFeature<Circle, CircleNameFeature>();
            circle.GetFeature<Circle, CircleLocationFeature>();
            circle.GetFeature<Circle, CircleGearFeature>();
            circle.GetFeature<Circle, CircleAbilitiesFeature>();
            circle.GetFeature<Circle, CircleResourcesFeature>();
            circle.GetFeature<Circle, CircleIlluminationFeature>();
        });

    [Fact]
    public void NewCircleWithoutLocation() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleLocationFeature>()
            .Location
            .ShouldBeNull();

    [Fact]
    public void NewCircleHasZeroIllumination() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Illumination
            .ShouldBe(0);

    [Fact]
    public void NewCircleHasZeroMilestone() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Milestone
            .ShouldBe(CircleMilestone.None);

    [Fact]
    public void NewCircleHasNoGear() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleGearFeature>()
            .Gear
            .ShouldBeEmpty();

    [Fact]
    public void NewCircleHasNoCharacters() =>
        CircleFactory.CreateCirle("Test circle").Characters.ShouldBeEmpty();

    [Fact]
    public void NewCircleHasOneOfEachResourceMax() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleResourcesFeature>()
            .ResourceMaximum
            .ShouldBe(1);

    [Theory]
    [InlineData(CircleResource.Stitch)]
    [InlineData(CircleResource.Refresh)]
    [InlineData(CircleResource.Train)]
    public void NewCircleHasOneOfEachResource(CircleResource resource) =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleResourcesFeature>()
            .Resources[resource]
            .ShouldBe(1);

    [Fact]
    public void NewCircleIsFirstRank() =>
        CircleFactory
            .CreateCirle("Test circle")
            .GetFeature<Circle, CircleIlluminationFeature>()
            .Rank
            .ShouldBe(1);
}
