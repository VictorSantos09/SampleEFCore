using Microsoft.EntityFrameworkCore;
using Sample.Core.Config;
using Sample.Core.Models;

namespace Sample.Core.Data;
public class SampleContext : DbContext
{
    public DbSet<PersonModel> People { get; set; }
    public DbSet<MovieModel> Movies { get; set; }
    public DbSet<PeopleMoviesModel> PeopleMovies { get; set; }
    public DbSet<GenreModel> Genres { get; set; }

    public SampleContext(DbContextOptions<SampleContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new PersonConfigurations());
        _ = modelBuilder.ApplyConfiguration(new MovieConfigurations());
        _ = modelBuilder.ApplyConfiguration(new PeopleMoviesConfigurations());
        _ = modelBuilder.ApplyConfiguration(new GenreConfigurations());
    }
}
