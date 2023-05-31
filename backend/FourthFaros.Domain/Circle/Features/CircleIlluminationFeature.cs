using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record CircleIlluminationFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_illumination";

    public override int Version => 1;

    public int Illumination { get; init; }

    public CircleMilestone Milestone =>
        (Illumination % 24) switch
        {
            < 7 => CircleMilestone.None,
            < 14 => CircleMilestone.First,
            < 21 => CircleMilestone.Second,
            <= 23 => CircleMilestone.Third,
            _ => throw new InvalidOperationException("Illumination cannot exceed 24")
        };

    public int Rank => 1 + (Illumination / 24);
}
