using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.Features;

public abstract record FeatureBase<T>(T Target) where T : FeatureTarget<T>
{
    public abstract string Code { get; }

    public abstract int Version { get; }

    public abstract object? GetData();

    public abstract FeatureBase<T> SetData(JToken? data);
}
