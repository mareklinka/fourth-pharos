using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Host.Extensions;
using FourthPharos.Host.Models;
using Microsoft.AspNetCore.Components;

namespace FourthPharos.Host.Pages.Circle;

public partial class CircleEditor
{
    [Parameter]
    public Guid? Id { get; set; }

    public CircleModel Model { get; set; } = null!;

    private Guid userId = Guid.Empty;

    private string circleName = string.Empty;
    private bool IsCircleNameInvalid => string.IsNullOrWhiteSpace(circleName);

    private string circleLocation = string.Empty;
    private bool IsCircleLocationInvalid => string.IsNullOrWhiteSpace(circleLocation);

    private Dictionary<CharacterRole, string> Roles = new() { { } }

    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        var authState = await authStateProvider.GetAuthenticationStateAsync();
        userId = authState.User.GetUserId();

        if (Id is null)
        {
            Model = circleService.CreateCircle("Circle of New Opportunity", userId);
        }
        else
        {
            var circle = circleService.GetCircles().SingleOrDefault(_ => _.Id == Id);

            if (circle is not null)
            {
                Model = circle;
                circleName = circle.Name;
            }
        }
    }

    private void SetName()
    {
        if (IsCircleNameInvalid)
        {
            return;
        }

        Model.Circle.SetName(circleName);
    }

    private void SetLocation()
    {
        if (IsCircleLocationInvalid)
        {
            return;
        }

        Model.Circle.SetLocation(circleLocation);
    }
}