using FourthPharos.Domain.CandelaObscuraCharacter.Models;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Features;

public sealed record CharacterBodyMarksFeature(Character Target) : CharacterMarksFeatureBase(Target)
{
    public override string Code => "char_marks_body";

    public override int Version => 1;

    public override ScarType ScarType => ScarType.Body;
}
