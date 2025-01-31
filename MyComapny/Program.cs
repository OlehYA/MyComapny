using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyComapny.Domain;
using MyComapny.Infrastructure;

namespace MyComapny
{
    public class Program
    { 
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Setings in configuration file appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Cover the section Project in object form for confortable

            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //Connection context DB
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
            

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
