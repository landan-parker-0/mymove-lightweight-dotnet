namespace mymove.api;

public record Startup(IConfiguration Configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddLogging();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment? env)
    {
        if (env?.IsDevelopment() is false)
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            
            endpoints.MapControllers();
        });
    }
}