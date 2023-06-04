using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleGearFeatureTest
{
    [Fact]
    public void PersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Ghostknife")
            .AddGear("Bleed Detector")
            .GetFeature<Circle, CircleGearFeature>();

        var json = JToken.FromObject(feature.GetData()!);

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Gear.ShouldBe(deserialized.Gear);
    }
}
