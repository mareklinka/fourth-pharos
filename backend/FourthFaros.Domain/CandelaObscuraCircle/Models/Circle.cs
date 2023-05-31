using System.Collections.Immutable;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Models;

public record Circle() : FeatureTarget<Circle>
{
    public ImmutableArray<object> Characters { get; init; } = ImmutableArray.Create<object>();
}
