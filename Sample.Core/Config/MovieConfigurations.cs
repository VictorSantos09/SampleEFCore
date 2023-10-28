using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Models;

namespace Sample.Core.Config;
internal class MovieConfigurations : IEntityTypeConfiguration<MovieModel>
{
    public void Configure(EntityTypeBuilder<MovieModel> builder)
    {
        _ = builder.ToTable("MOVIES");

        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        _ = builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("varchar(45)")
            .HasColumnName("TITLE");

        _ = builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasColumnName("DESCRIPTION");

        _ = builder.Property(x => x.GenreId)
            .IsRequired()
            .HasColumnType("INT")
            .HasColumnName("ID_GENRE");

        _ = builder.HasIndex(x => x.Id, "IDX_MOVIES_001")
            .IsUnique();
        _ = builder.HasIndex(x => x.Title, "IDX_MOVIES_002")
            .IsUnique();
        _ = builder.HasIndex(x => x.GenreId, "IND_MOVIES_001");

        _ = builder.HasOne(x => x.Genre)
             .WithMany()
             .HasForeignKey(x => x.GenreId)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK_MOVIES_GENRES_001");
    }
}
