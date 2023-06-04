using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;
using FourthPharos.Domain.Models;

namespace FourthPharos.Domain.CandelaObscuraCircle.Models;

public record Circle(Guid Id, Guid OwnerId) : FeatureTarget<Circle>, IAddressable, IOwned
{
    public ImmutableArray<Character> Characters { get; internal set; } = ImmutableArray.Create<Character>();
}
