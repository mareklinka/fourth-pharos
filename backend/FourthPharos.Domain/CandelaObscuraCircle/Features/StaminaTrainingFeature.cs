using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record StaminaTrainingFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_stamina_training";

    public override int Version => 1;

    public int StaminaDice { get; init; } = 3;
}
