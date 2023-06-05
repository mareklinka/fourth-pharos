using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Models;

namespace FourthPharos.Domain.Features;

public static class FeatureExtensions
{
    public static TFeature? TryGetFeature<TFeature>(this Circle target)
        where TFeature : FeatureBase<Circle> =>
        target.Features.OfType<TFeature>().FirstOrDefault();

    public static TFeature? TryGetFeature<TFeature>(this Character target)
        where TFeature : FeatureBase<Character> =>
        target.Features.OfType<TFeature>().FirstOrDefault();

    public static TFeature GetFeature<TFeature>(this Circle target)
        where TFeature : FeatureBase<Circle> =>
        target.Features.OfType<TFeature>().FirstOrDefault() switch
        {
            null => throw DomainExceptions.FeatureExceptions.FeatureNotAttached(typeof(TFeature).Name),
            TFeature f => f
        };

    public static TFeature GetFeature<TFeature>(this Character target)
        where TFeature : FeatureBase<Character> =>
        target.Features.OfType<TFeature>().FirstOrDefault() switch
        {
            null => throw DomainExceptions.FeatureExceptions.FeatureNotAttached(typeof(TFeature).Name),
            TFeature f => f
        };

    public static TTarget UpdateFeature<TTarget, TFeature>(this TTarget target, TFeature feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        target.Features = target.Features.Remove(feature).Add(feature);

        return target;
    }

    public static TTarget AddFeature<TTarget, TFeature>(this TTarget target, Func<TTarget, TFeature> feature)
        where TTarget : FeatureTarget<TTarget>
        where TFeature : FeatureBase<TTarget>
    {
        target.Features = target.Features.Add(feature(target));

        return target;
    }

    public static Circle RemoveFeature<TFeature>(this Circle target)
        where TFeature : FeatureBase<Circle>
    {
        var feature = target.TryGetFeature<TFeature>();

        if (feature is not null)
        {
            target.Features = target.Features.Remove(feature);
        }

        return target;
    }

    public static Character RemoveFeature<TFeature>(this Character target)
        where TFeature : FeatureBase<Character>
    {
        var feature = target.TryGetFeature<TFeature>();

        if (feature is not null)
        {
            target.Features = target.Features.Remove(feature);
        }

        return target;
    }
}
