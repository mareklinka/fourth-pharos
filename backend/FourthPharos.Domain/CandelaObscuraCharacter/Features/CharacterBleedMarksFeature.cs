using FourthPharos.Domain.CandelaObscuraCharacter.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterBleedMarksFeature(Character Target) : CharacterMarksFeatureBase(Target)
{
    public override string Code => "char_marks_bleed";

    public override int Version => 1;

    public override ScarType ScarType => ScarType.Bleed;
}
