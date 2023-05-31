using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Features;

public sealed record StaminaTrainingFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_stamina_training";

    public override int Version => 1;

    public int StaminaDice { get; init; } = 3;
}
