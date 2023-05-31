using FourthPharos.Domain.CandelaObscuraCircle;

namespace FourthPharos.Domain.Tests.Features;

public class FeatureExtensionsTest
{
    [Fact]
    public void UpdateFeatureUpdatesTargets()
    {
        var circle = CircleFactory.CreateCirle("Test Circle");

        circle.Features.ShouldAllBe(_ => _.Target == circle);
    }
}