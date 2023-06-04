using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using Newtonsoft.Json.Linq;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public abstract record CharacterDriveFeatureBase(Character Target) : FeatureBase<Character>(Target)
{
    public int Drive { get; init; }

    public int DriveMax { get; init; }

    public ImmutableDictionary<string, CharacterAction> Actions { get; init; } = ImmutableDictionary.Create<string, CharacterAction>();

    public int Resistance { get; init; }

    public int ResistanceMax => DriveMax / 3;

    public override object GetData() => Actions;

    public override FeatureBase<Character> SetData(JToken? data) =>
        data switch
        {
            JObject o => this with
            {
                Actions = ImmutableDictionary.CreateRange(o.Properties().Select(_ => KeyValuePair.Create(_.Name, _.Value<CharacterAction>()!)))
            },
            _ => throw DomainExceptions.StorageExceptions.InvalidFeatureDataFormat(Code, Version, data)
        };
}
