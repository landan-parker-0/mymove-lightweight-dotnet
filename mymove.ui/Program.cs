namespace mymove.ui;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("blazor server");
        CreateHostBuilder(args:args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(Action<IServiceCollection> setServices = null!, Action<IServiceCollection> servicesBeforeStartup = null!, params string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                if(servicesBeforeStartup is not null)
                    webBuilder.ConfigureServices(servicesBeforeStartup);

                webBuilder.UseStartup<Startup>();
                if(args is { Length: > 0 })
                    webBuilder.UseUrls(args);
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {

            })
            .ConfigureServices(services =>
            {
                setServices?.Invoke(services);
            });
}