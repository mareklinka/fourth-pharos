using FourthPharos.Host.Extensions;

namespace FourthPharos.Host.Pages;

public partial class MyCircles
{
    private string _newCircleName = string.Empty;

    private Guid _userId = Guid.Empty;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        _userId = authState.User.GetUserId();
    }

    private void CreateCircle(string name) => circleService.CreateCircle(name, _userId);
}