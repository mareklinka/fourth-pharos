using System.Collections.Immutable;

namespace FourthFaros.Domain.Circle.Models;

public record CircleBase(string Name, string? Location = null)
{
    public CircleMilestone Milestone =>
        Illumination switch
        {
            < 7 => CircleMilestone.None,
            < 14 => CircleMilestone.First,
            < 21 => CircleMilestone.Second,
            <= 23 => CircleMilestone.Third,
            _ => throw new InvalidOperationException("Illumination cannot exceed 24")
        };

    public ImmutableArray<CircleGear> Gear { get; init; } = ImmutableArray.Create<CircleGear>();

    public ImmutableArray<object> Characters { get; init; } = ImmutableArray.Create<object>();

    public ImmutableArray<CircleAbility> Abilities { get; init; } = ImmutableArray.Create<CircleAbility>();

    public ImmutableDictionary<CircleResource, int> Resources { get; init; } =
        ImmutableDictionary.CreateRange(
            new KeyValuePair<CircleResource, int>[] {
                KeyValuePair.Create(CircleResource.Stitch, 1),
                KeyValuePair.Create(CircleResource.Refresh, 1),
                KeyValuePair.Create(CircleResource.Train, 1)
            });

    public int Illumination { get; init; }

    public int ResourceMaximum => Characters.Length + 1;

    public int Rank { get; init; } = 1;

    // this is a very straight-forward implementation
    // a more generic implementation might be useful later on
    public int StaminaDice { get; init; }
}
