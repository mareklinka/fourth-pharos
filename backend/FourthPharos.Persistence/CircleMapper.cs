using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
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
                _.GetFeature<Character, CharacterBasicInfoFeature>().Name)).ToArray(),
            circle.Features.Select(_ => new FeatureStorageWriteModel(
                _.Code,
                _.Version,
                _.GetData())).ToArray());

    public static Circle FromStorageModel(CircleStorageReadModel circleModel)
    {
        var c = new Circle(Guid.ParseExact(circleModel.Id, "D"), Guid.ParseExact(circleModel.OwnerId, "D"));

        foreach (var fm in circleModel.Features)
        {
            FeatureBase<Circle> f = (fm.FeatureCode, fm.Version) switch
            {
                (CircleNameFeature.FeatureCode, CircleNameFeature.FeatureVersion) => new CircleNameFeature(c).SetData(fm.Data),
                (CircleAbilitiesFeature.FeatureCode, CircleAbilitiesFeature.FeatureVersion) => new CircleAbilitiesFeature(c).SetData(fm.Data),
                (CircleGearFeature.FeatureCode, CircleGearFeature.FeatureVersion) => new CircleGearFeature(c).SetData(fm.Data),
                (CircleIlluminationFeature.FeatureCode, CircleIlluminationFeature.FeatureVersion) => new CircleIlluminationFeature(c).SetData(fm.Data),
                (CircleLocationFeature.FeatureCode, CircleLocationFeature.FeatureVersion) => new CircleLocationFeature(c).SetData(fm.Data),
                (CircleResourcesFeature.FeatureCode, CircleResourcesFeature.FeatureVersion) => new CircleResourcesFeature(c).SetData(fm.Data),
                (StaminaTrainingFeature.FeatureCode, StaminaTrainingFeature.FeatureVersion) => new StaminaTrainingFeature(c).SetData(fm.Data),
                _ => throw new InvalidOperationException("Unknown feature encountered")
            };

            c.Features = c.Features.Add(f);
        }

        return c;
    }
}
