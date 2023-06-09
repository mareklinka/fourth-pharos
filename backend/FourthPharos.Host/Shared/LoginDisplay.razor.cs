using System.Security.Claims;

namespace FourthPharos.Host.Shared;

public partial class LoginDisplay
{
    private bool canEditProfile;
    private string? username;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        username = authState.User.FindFirstValue("extension_Username");

        var options = microsoftIdentityOptions.CurrentValue;
        canEditProfile = !string.IsNullOrEmpty(options.EditProfilePolicyId);
    }
}