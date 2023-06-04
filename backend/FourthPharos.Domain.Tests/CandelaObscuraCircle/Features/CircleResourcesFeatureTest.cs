using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Features;

public class CircleResourcesFeatureTest
{
    [Fact]
    public void PersistenceTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<Circle, CircleResourcesFeature>();

        var json = JToken.FromObject(feature.GetData()!);

        var deserialized = feature.SetData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Resources.ShouldBe(deserialized.Resources);
    }
}
