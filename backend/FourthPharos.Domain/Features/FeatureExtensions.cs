namespace FourthPharos.Domain.Features;

public static class FeatureExtensions
{
    public static TFeature? TryGetFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget> =>
        target.Features.OfType<TFeature>().FirstOrDefault();

    public static TFeature GetFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget> =>
        target.Features.OfType<TFeature>().FirstOrDefault() switch
        {
            null => throw DomainExceptions.FeatureExceptions.FeatureNotAttached(typeof(TFeature).Name),
            TFeature f => f
        };

    public static TTarget UpdateFeature<TTarget, TFeature>(this TTarget target, TFeature feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        var t = target.RemoveFeature<TTarget, TFeature>();
        t.Features = t.Features.Add(feature);

        return t;
    }

    public static TTarget AddFeature<TTarget, TFeature>(this TTarget target, Func<TTarget, TFeature> feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        if (target.Features.OfType<TFeature>().Any())
        {
            throw DomainExceptions.FeatureExceptions.FeatureAlreadyAttached(typeof(TFeature).Name);
        }

        target.Features = target.Features.Add(feature(target));

        return target;
    }

    public static TTarget RemoveFeature<TTarget, TFeature>(this TTarget target)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        var feature = target.TryGetFeature<TTarget, TFeature>();

        if (feature is not null)
        {
            target.Features = target.Features.Remove(feature);
        }

        return target;
    }
}
