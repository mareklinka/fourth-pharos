using System.Collections.Immutable;
using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleResourcesFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_resources";

    public override int Version => 1;

    public ImmutableDictionary<CircleResource, int> Resources { get; init; } =
        ImmutableDictionary.CreateRange(
            new KeyValuePair<CircleResource, int>[] {
                KeyValuePair.Create(CircleResource.Stitch, 1),
                KeyValuePair.Create(CircleResource.Refresh, 1),
                KeyValuePair.Create(CircleResource.Train, 1)
            });

    public int ResourceMaximum => Target.Characters.Length + 1;
}
