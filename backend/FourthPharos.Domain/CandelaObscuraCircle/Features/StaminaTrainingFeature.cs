using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record StaminaTrainingFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public const string FeatureCode = "circle_stamina_training";

    public const int FeatureVersion = 1;

    public override string Code => FeatureCode;

    public override int Version => FeatureVersion;

    public int StaminaDice { get; init; } = 3;
}
