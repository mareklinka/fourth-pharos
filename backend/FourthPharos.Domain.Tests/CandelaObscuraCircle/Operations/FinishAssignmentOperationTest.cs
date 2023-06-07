using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class FinishAssignmentOperationTest
{
    [Fact]
    public void FinishAssignment()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .StartAssignment()
            .FinishAssignment();

        var feature = circle.GetFeature<Circle, CircleActiveAssignmentFeature>();

        feature.IsAssignmentActive.ShouldBeFalse();
        feature.AssignmentStartUtc.ShouldBeNull();
    }

    [Fact]
    public void StartAssignmentWhenAlreadyStartedFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
                .CreateCirle("Test Circle")
                .FinishAssignment())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.NoActiveAssignment));
    }
}
