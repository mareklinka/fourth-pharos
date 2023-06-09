namespace FourthPharos.Host.Shared;

public partial class MainLayout
{
    private bool isAuthenticated;
    private bool isSidebarExpanded = true;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        isAuthenticated = authState.User.Identity?.IsAuthenticated is true;
    }
}