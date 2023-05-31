using System.Diagnostics.CodeAnalysis;

namespace FourthFaros.Domain.Features;

internal sealed class FeatureComparer<TTarget> : IEqualityComparer<FeatureBase<TTarget>>
        where TTarget : FeatureTarget<TTarget>
{
    public static FeatureComparer<TTarget> Instance { get; } = new();

    private FeatureComparer()
    {
    }

    public bool Equals(FeatureBase<TTarget>? x, FeatureBase<TTarget>? y) =>
        ReferenceEquals(x, y) || (string.Equals(x?.Code, y?.Code, StringComparison.Ordinal) && x?.Version == y?.Version);

    public int GetHashCode([DisallowNull] FeatureBase<TTarget> obj) => HashCode.Combine(obj.Code, obj.Version);
}
