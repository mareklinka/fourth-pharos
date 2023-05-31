namespace FourthFaros.Domain.Features;

public static class FeatureExtensions
{
    public static TFeature? TryGetFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget> =>
        target.Features.OfType<TFeature>().FirstOrDefault();

    public static TFeature GetFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        var feature = target.Features.OfType<TFeature>().FirstOrDefault();

        return feature switch
        {
            null => throw DomainExceptions.FeatureExceptions.FeatureNotAttached(typeof(TFeature).Name),
            _ => feature
        };
    }

    public static TTarget UpdateFeature<TTarget, TFeature>(this TTarget target, TFeature feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget> =>
        target with { Features = target.Features.Remove(feature).Add(feature) };

    public static TTarget AddFeature<TTarget, TFeature>(this TTarget target, Func<TTarget, TFeature> feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget> =>
        target with { Features = target.Features.Add(feature(target)) };

    public static TTarget RemoveFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        var existingFeature = target.TryGetFeature<TTarget, TFeature>();
        return existingFeature switch
        {
            null => target,
            _ => target with { Features = target.Features.Remove(existingFeature) }
        };
    }
}
