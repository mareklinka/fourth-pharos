using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record Character(Guid Id, Guid OwnerId) : FeatureTarget<Character>, IAddressable, IOwned
{
    public Circle? Circle { get; internal set; }
}
