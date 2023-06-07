using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class StartAssignmentOperation
{
    public static Circle StartAssignment(this Circle circle)
    {
        var feature = circle.GetFeature<Circle, CircleActiveAssignmentFeature>();

        if (feature.IsAssignmentActive)
        {
            throw DomainExceptions.CircleExceptions.AssignmentAlreadyActive();
        }

        return circle.UpdateFeature(feature with
        {
            IsAssignmentActive = true,
            AssignmentStartUtc = DateTime.UtcNow
        });
    }
}
