namespace GitHubProxy;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ServiceConfiguration.ConfigureServices(builder.Services);

        var app = builder.Build();

        app
            .UseHttpsRedirection()
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "proxy",
                    pattern: "{*path}",
                    defaults: new { controller = "Proxy", action = "Handle" });
            });

        app.Run();
    }
}