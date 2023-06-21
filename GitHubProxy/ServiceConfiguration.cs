using Core;
namespace GitHubProxy;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        CoreServiceConfiguration
            .ConfigureServices(services)
            .AddHttpClient()
            .AddControllers();

        return services;
    }
}
