using System.Collections.Immutable;

namespace FourthPharos.Domain.Features;

public abstract record FeatureTarget<TTarget> where TTarget : FeatureTarget<TTarget>
{
    public ImmutableHashSet<FeatureBase<TTarget>> Features { get; internal set; } =
        ImmutableHashSet.Create<FeatureBase<TTarget>>(FeatureComparer<TTarget>.Instance);
}
