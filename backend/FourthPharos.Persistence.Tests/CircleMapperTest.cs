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
        deserialized.GetFeature<CircleNameFeature>().Name.ShouldBe(c.GetFeature<CircleNameFeature>().Name);
        deserialized.GetFeature<CircleLocationFeature>().Location.ShouldBe(c.GetFeature<CircleLocationFeature>().Location);
        deserialized.GetFeature<StaminaTrainingFeature>().StaminaDice.ShouldBe(c.GetFeature<StaminaTrainingFeature>().StaminaDice);
        deserialized.GetFeature<CircleGearFeature>().Gear.ShouldBe(c.GetFeature<CircleGearFeature>().Gear);
        deserialized.GetFeature<CircleResourcesFeature>().Resources.ShouldBe(c.GetFeature<CircleResourcesFeature>().Resources);
        deserialized.GetFeature<CircleIlluminationFeature>().Illumination.ShouldBe(c.GetFeature<CircleIlluminationFeature>().Illumination);
    }
}
