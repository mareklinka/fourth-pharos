using System.Globalization;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Persistence;

public static class CircleMapper
{
    public static CircleStorageWriteModel ToStorageModel(Circle circle) =>
        new(
            circle.Id.ToString(),
            circle.OwnerId.ToString("D"),
            circle.Characters.Select(_ => new CharacterReference(
                _.Id.ToString("D"),
                _.OwnerId.ToString("D"),
                _.GetFeature<CharacterBasicInfoFeature>().Name)).ToArray(),
            circle.Features.ToDictionary(_ => $"{_.Code}-{_.Version}", _ => _.GetFeatureData()));

    public static Circle FromStorageModel(CircleStorageReadModel circleModel)
    {
        var c = new Circle(Guid.ParseExact(circleModel.Id, "D"), Guid.ParseExact(circleModel.OwnerId, "D"));

        foreach (var fm in circleModel.Features)
        {
            var split = fm.Key.Split("-");

            FeatureBase<Circle> f = (split[0], int.Parse(split[1], CultureInfo.InvariantCulture)) switch
            {
                (CircleNameFeature.FeatureCode, CircleNameFeature.FeatureVersion) => new CircleNameFeature(c),
                (CircleAbilitiesFeature.FeatureCode, CircleAbilitiesFeature.FeatureVersion) => new CircleAbilitiesFeature(c),
                (CircleGearFeature.FeatureCode, CircleGearFeature.FeatureVersion) => new CircleGearFeature(c),
                (CircleIlluminationFeature.FeatureCode, CircleIlluminationFeature.FeatureVersion) => new CircleIlluminationFeature(c),
                (CircleLocationFeature.FeatureCode, CircleLocationFeature.FeatureVersion) => new CircleLocationFeature(c),
                (CircleResourcesFeature.FeatureCode, CircleResourcesFeature.FeatureVersion) => new CircleResourcesFeature(c),
                (StaminaTrainingFeature.FeatureCode, StaminaTrainingFeature.FeatureVersion) => new StaminaTrainingFeature(c),
                _ => throw new InvalidOperationException("Unknown feature encountered")
            };

            c.Features = c.Features.Add(f.SetFeatureData(fm.Value));
        }

        return c;
    }
}
