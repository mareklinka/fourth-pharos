using FourthPharos.Host.Services;

namespace FourthPharos.Host.Configuration;
public static class ServiceConfiguration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
#if DEBUG
        services.AddSassCompiler();
#endif

        services.AddScoped<ICircleService, CircleService>();

        return services;
    }
}
