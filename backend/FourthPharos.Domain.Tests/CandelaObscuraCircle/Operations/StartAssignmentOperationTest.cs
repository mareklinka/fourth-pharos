using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCircle.Operations;

public class StartAssignmentOperationTest
{
    [Fact]
    public void StartAssignment()
    {
        var circle = CircleFactory
            .CreateCirle("Test Circle")
            .StartAssignment();

        var feature = circle.GetFeature<Circle, CircleActiveAssignmentFeature>();

        feature.IsAssignmentActive.ShouldBeTrue();
        feature.AssignmentStartUtc.ShouldNotBeNull();
    }

    [Fact]
    public void StartAssignmentWhenAlreadyStartedFails()
    {
        Should.Throw<DomainActionException>(() => CircleFactory
                .CreateCirle("Test Circle")
                .StartAssignment()
                .StartAssignment())
            .Code
            .ShouldBe(nameof(DomainExceptions.CircleExceptions.AssignmentAlreadyActive));
    }
}
