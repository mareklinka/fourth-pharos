using FourthFaros.Domain.Circle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.Circle.Features;

public sealed record StaminaTrainingFeature(CircleBase Target) : FeatureBase<CircleBase>(Target)
{
    public override string Code => "circle_stamina_training";

    public override int Version => 1;

    public int StaminaDice { get; init; } = 3;
}
