using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Models;

namespace Sample.Core.Config;
internal class PeopleMoviesConfigurations : IEntityTypeConfiguration<PeopleMoviesModel>
{
    public void Configure(EntityTypeBuilder<PeopleMoviesModel> builder)
    {
        _ = builder.ToTable("PEOPLE_MOVIES");

        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        _ = builder.Property(x => x.PersonId)
            .HasColumnType("INT")
            .HasColumnName("ID_PERSON");
        _ = builder.Property(builder => builder.MovieId)
            .HasColumnType("INT")
            .HasColumnName("ID_MOVIE");

        _ = builder.Property(x => x.Date)
            .HasColumnName("DATE");

        _ = builder.HasIndex(x => x.Id, "IDX_PEOPLE_MOVIES_001")
            .IsUnique();
        _ = builder.HasIndex(x => x.PersonId, "IND_PEOPLE_MOVIES_001");
        _ = builder.HasIndex(x => x.MovieId, "IND_PEOPLE_MOVIES_002");

        _ = builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PEOPLE_MOVIES_PEOPLE_001");

        _ = builder.HasOne(x => x.Movie)
            .WithMany()
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PEOPLE_MOVIES_MOVIES_002");
    }
}