using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class FinishAssignmentOperation
{
    public static Circle FinishAssignment(this Circle circle)
    {
        var feature = circle.GetFeature<Circle, CircleActiveAssignmentFeature>();

        if (!feature.IsAssignmentActive)
        {
            throw DomainExceptions.CircleExceptions.NoActiveAssignment();
        }

        return circle.UpdateFeature(feature with
        {
            IsAssignmentActive = false,
            AssignmentStartUtc = null
        });
    }
}
