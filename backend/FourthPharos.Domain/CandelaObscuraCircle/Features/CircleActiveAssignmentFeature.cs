using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Features;

public sealed record CircleActiveAssignmentFeature(Circle Target) : FeatureBase<Circle>(Target)
{
    public override string Code => "circle_active_assignment";

    public override int Version => 1;

    public bool IsAssignmentActive { get; init; }

    public DateTime? AssignmentStartUtc { get; init; }
}
