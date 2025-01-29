using MyComapny.Infrastructure;

namespace MyComapny
{
    public class Program
    { 
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Setings in configuration file appsettings.json
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Cover the section Project in object form for confortable

            IConfiguration configuration = configBuilder.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //Setings functions controllers
            builder.Services.AddControllersWithViews();

            //Created configuration
            WebApplication app = builder.Build();

            //Setings utilizing static fails (js, css, other)
            app.UseStaticFiles();

            //Setings sustem routing
            app.UseRouting();

            //registration need us routing

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

           await app.RunAsync();
        }
    }
}
