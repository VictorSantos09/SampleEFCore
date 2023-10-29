using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Core.Data;
using Sample.Core.Models;
using Sample.Core.Services;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Config;
public class SampleConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddScoped<PersonService>();
        _ = services.AddScoped<MovieService>();
        _ = services.AddScoped<GenreService>();
        _ = services.AddScoped<PeopleMoviesService>();

        ConfigureContracts(services);
        ConfigureDatabase(services);
    }

    private static void ConfigureContracts(IServiceCollection services)
    {
        _ = services.AddScoped<IService<PersonModel>, PersonService>();
        _ = services.AddScoped<IService<MovieModel>, MovieService>();
        _ = services.AddScoped<IService<GenreModel>, GenreService>();
        _ = services.AddScoped<IPeopleMoviesService, PeopleMoviesService>();
        _ = services.AddScoped<IGenreService, GenreService>();
    }

    private static void ConfigureDatabase(IServiceCollection services)
    {
        string mySqlConnectionStr = "server=localhost; port=3306; database=test; user=root; password=root; Persist Security Info=False; Connect Timeout=300";
        _ = services.AddDbContextPool<SampleContext>(options =>
        {
            _ = options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), x => x.MigrationsAssembly("View"));
        });

        _ = services.AddTransient<SampleContext>();
    }
}
