using System.Collections.Immutable;
using FourthFaros.Domain.CandelaObscuraCharacter.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Models;

public record Circle : FeatureTarget<Circle>
{
    public ImmutableArray<Character> Characters { get; internal set; } = ImmutableArray.Create<Character>();
}
