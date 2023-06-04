using Newtonsoft.Json.Linq;

namespace FourthPharos.Persistence;

public sealed record FeatureStorageWriteModel(string FeatureCode, int Version, object? Data);
public sealed record CircleStorageWriteModel(
    string Id,
    string OwnerId,
    ICollection<CharacterReference> Characters,
    ICollection<FeatureStorageWriteModel> Features);

public sealed record FeatureStorageReadModel(string FeatureCode, int Version, JToken? Data);
public sealed record CircleStorageReadModel(
    string Id,
    string OwnerId,
    ICollection<CharacterReference> Characters,
    ICollection<FeatureStorageReadModel> Features);

public sealed record CharacterReference(string Id, string OwnerId, string Name);
