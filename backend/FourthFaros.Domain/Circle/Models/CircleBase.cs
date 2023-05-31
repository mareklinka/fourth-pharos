using System.Collections.Immutable;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Models;

public record CircleBase() : FeatureTarget<CircleBase>
{
    public ImmutableArray<object> Characters { get; init; } = ImmutableArray.Create<object>();
}
