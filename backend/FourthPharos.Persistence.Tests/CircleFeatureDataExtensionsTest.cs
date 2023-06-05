using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Persistence.Tests;

public class CircleFeatureDataExtensionsTest
{
    [Fact]
    public void StaminaTrainingTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddAbility(CircleAbility.StaminaTraining)
            .GetFeature<StaminaTrainingFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.StaminaDice.ShouldBe(deserialized.StaminaDice);
    }

    [Fact]
    public void ResourcesTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<CircleResourcesFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Resources.ShouldBe(deserialized.Resources);
    }

    [Fact]
    public void NameTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .SetName("Circle of Darkfire")
            .GetFeature<CircleNameFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Name.ShouldBe(deserialized.Name);
    }

    [Fact]
    public void AbilitiesTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(200)
            .AddAbility(CircleAbility.ForgedInFire)
            .AddAbility(CircleAbility.Interdisciplinary)
            .AddAbility(CircleAbility.NobodyLeftBehind)
            .AddAbility(CircleAbility.OneLastRun)
            .AddAbility(CircleAbility.ResourceManagement)
            .AddAbility(CircleAbility.StaminaTraining)
            .GetFeature<CircleAbilitiesFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Abilities.ShouldBe(deserialized.Abilities);
    }

    [Fact]
    public void LocationTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .SetLocation("Tower of Inquiry")
            .GetFeature<CircleLocationFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Location.ShouldBe(deserialized.Location);
    }

    [Fact]
    public void NullLocationTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .GetFeature<CircleLocationFeature>();

        var json = JToken.Parse("null");

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Location.ShouldBe(deserialized.Location);
    }

    [Fact]
    public void GearTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddGear("Ghostknife")
            .AddGear("Bleed Detector")
            .GetFeature<CircleGearFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Gear.ShouldBe(deserialized.Gear);
    }

    [Fact]
    public void IlluminationTest()
    {
        var feature = CircleFactory
            .CreateCirle("Test Circle")
            .AddIllumination(10)
            .GetFeature<CircleIlluminationFeature>();

        var json = JToken.FromObject(feature.GetFeatureData()!);

        var deserialized = feature.SetFeatureData(json);

        feature.ShouldNotBeSameAs(deserialized);
        feature.Illumination.ShouldBe(deserialized.Illumination);
    }
}