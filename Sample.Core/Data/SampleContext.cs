using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.Core.Config;
using Sample.Core.Models;
using System.Reflection.Emit;

namespace Sample.Core.Data;
public class SampleContext : IdentityDbContext
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

        ConfigureIdentity(modelBuilder);
    }

    private static void ConfigureIdentity(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<IdentityUser>()
            .ToTable("Users")
            .HasKey(x => x.Id);

        _ = modelBuilder.Entity<IdentityUserLogin<string>>(e => e
        .HasKey(identity => identity.UserId));

        modelBuilder.Entity<IdentityUserRole<string>>()
             .HasKey(e => new { e.UserId, e.RoleId });

        _ = modelBuilder.Entity<IdentityRole<string>>()
          .HasKey(e => e.Id);

        _ = modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
    }
}
