using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public abstract record CharacterMarksFeatureBase(Character Target) : FeatureBase<Character>(Target)
{
    public int Marks { get; init; }

    public abstract ScarType ScarType { get; }
}
