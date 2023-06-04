using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Persistence.Tests;

public class CircleMapperTest
{
    [Fact]
    public void EndToEndTest()
    {
        var c = CircleFactory.CreateCirle("Circle of the Crimson Tear")
            .AddAbility(CircleAbility.StaminaTraining)
            .AddGear("Bleed Detector")
            .AddIllumination(10)
            .SetLocation("The Weeping House")
            .ConsumeResource(CircleResource.Stitch)
            .ConsumeStaminaDice();

        var writeModel = CircleMapper.ToStorageModel(c);
        var json = JObject.FromObject(writeModel);

        var readModel = json.ToObject<CircleStorageReadModel>()!;
        var deserialized = CircleMapper.FromStorageModel(readModel);

        deserialized.ShouldNotBeSameAs(c);
        deserialized.GetFeature<Circle, CircleNameFeature>().Name.ShouldBe(c.GetFeature<Circle, CircleNameFeature>().Name);
        deserialized.GetFeature<Circle, CircleLocationFeature>().Location.ShouldBe(c.GetFeature<Circle, CircleLocationFeature>().Location);
        deserialized.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice.ShouldBe(c.GetFeature<Circle, StaminaTrainingFeature>().StaminaDice);
        deserialized.GetFeature<Circle, CircleGearFeature>().Gear.ShouldBe(c.GetFeature<Circle, CircleGearFeature>().Gear);
        deserialized.GetFeature<Circle, CircleResourcesFeature>().Resources.ShouldBe(c.GetFeature<Circle, CircleResourcesFeature>().Resources);
        deserialized.GetFeature<Circle, CircleIlluminationFeature>().Illumination.ShouldBe(c.GetFeature<Circle, CircleIlluminationFeature>().Illumination);
    }
}
