using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleResourcesFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_resources";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public ImmutableDictionary<CircleResource, int> Resources { get; init; } =
        ImmutableDictionary.CreateRange(
            new KeyValuePair<CircleResource, int>[] {
                KeyValuePair.Create(CircleResource.Stitch, 1),
                KeyValuePair.Create(CircleResource.Refresh, 1),
                KeyValuePair.Create(CircleResource.Train, 1)
            });

    public int ResourceMaximum => Target.Characters.Length + 1;
}
