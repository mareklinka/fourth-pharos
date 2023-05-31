using System.Collections.Immutable;

namespace FourthFaros.Domain.Features;

public abstract record FeatureTarget<TTarget> where TTarget : FeatureTarget<TTarget>
{
    public ImmutableHashSet<FeatureBase<TTarget>> Features { get; init; } =
        ImmutableHashSet.Create<FeatureBase<TTarget>>(FeatureComparer<TTarget>.Instance);
}
