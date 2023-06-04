using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleLocationFeatureTest
{
    [Fact]
    public void PersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .SetLocation("Tower of Inquiry")
            .GetFeature<Circle, CircleLocationFeature>();

        var json = JToken.FromObject(feature.GetData()!);

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Location.ShouldBe(deserialized.Location);
    }

    [Fact]
    public void NullPersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<Circle, CircleLocationFeature>();

        var json = JToken.Parse("null");

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Location.ShouldBe(deserialized.Location);
    }
}
