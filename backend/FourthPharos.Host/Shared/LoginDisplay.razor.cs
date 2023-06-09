using System.Security.Claims;

namespace FourthPharos.Host.Shared;

public partial class LoginDisplay
{
    private bool _canEditProfile;
    private string? _username;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        _username = authState.User.FindFirstValue("extension_Username");

        var options = microsoftIdentityOptions.CurrentValue;
        _canEditProfile = !string.IsNullOrEmpty(options.EditProfilePolicyId);
    }
}