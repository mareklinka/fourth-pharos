namespace FourthPharos.Host.Shared;

public partial class MainLayout
{
    private bool _isAuthenticated;
    private bool _isSidebarExpanded = true;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        _isAuthenticated = authState.User.Identity?.IsAuthenticated is true;
    }
}