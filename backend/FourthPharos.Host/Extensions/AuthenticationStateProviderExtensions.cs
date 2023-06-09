using System.Security.Claims;

namespace FourthPharos.Host.Extensions;

public static class AuthenticationStateProvideExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal) =>
        Guid.Parse(principal.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier")!);

}