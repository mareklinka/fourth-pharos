using System.Collections.Immutable;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Models;

public record Circle : FeatureTarget<Circle>
{
    public ImmutableArray<Character> Characters { get; internal set; } = ImmutableArray.Create<Character>();
}
