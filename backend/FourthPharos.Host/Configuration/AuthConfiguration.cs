using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

namespace FourthPharos.Host.Configuration;

public static class AuthConfiguration
{
    public static IServiceCollection RegisterAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAdB2C"));

        services.AddAuthorization(options =>
        {
            // By default, all incoming requests will be authorized according to the default policy
            options.FallbackPolicy = null;
        });

        services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            // Configures the Sign Out action to redirect back to the home page, which will navigate to the login page
            options.Events.OnSignedOutCallbackRedirect = context =>
            {
                context.HttpContext.Response.Redirect(context.Options.SignedOutRedirectUri);
                context.HandleResponse();

                return Task.CompletedTask;
            };
        });

        return services;
    }
}