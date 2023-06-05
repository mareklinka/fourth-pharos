using Newtonsoft.Json.Linq;

namespace FourthPharos.Persistence;

public sealed record CircleStorageWriteModel(
    string Id,
    string OwnerId,
    ICollection<CharacterReference> Characters,
    IReadOnlyDictionary<string, object?> Features);

public sealed record FeatureStorageReadModel(string FeatureCode, int Version, JToken? Data);
public sealed record CircleStorageReadModel(
    string Id,
    string OwnerId,
    ICollection<CharacterReference> Characters,
    IReadOnlyDictionary<string, JToken?> Features);

public sealed record CharacterReference(string Id, string OwnerId, string Name);
