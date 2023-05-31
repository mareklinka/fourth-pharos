using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Models;

public sealed record Character : FeatureTarget<Character>
{
    public Circle? Circle { get; internal set; }
}
