
namespace mymove.ui;

public record Startup(IConfiguration Configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddControllers();
        services.AddServerSideBlazor();
        services.AddHttpContextAccessor();
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

        const string ITEM_IS_404 = nameof(ITEM_IS_404);

        app.UseRouting();
        app.UseStatusCodePagesWithRedirects("/error/{0}");
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            Console.WriteLine("");
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}