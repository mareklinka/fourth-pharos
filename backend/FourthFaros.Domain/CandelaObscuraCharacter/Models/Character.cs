using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCharacter.Models;

public sealed record Character : FeatureTarget<Character>
{
    public Circle? Circle { get; internal set; }
}
