using Core.PageDownload;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CoreServiceConfiguration).Assembly))
                .AddSingleton<IPageDownloader, PageDownloader>();

            return services;
        }
    }
}
