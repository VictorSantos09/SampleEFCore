using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Models;

namespace Sample.Core.Config;
internal class GenreConfigurations : IEntityTypeConfiguration<GenreModel>
{
    public void Configure(EntityTypeBuilder<GenreModel> builder)
    {
        _ = builder.ToTable("GENRES");

        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        _ = builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(45)")
            .HasColumnName("NAME");

        _ = builder.HasIndex(x => x.Id, "IDX_GENRES_001")
            .IsUnique();

        _ = builder.HasIndex(x => x.Name, "IDX_GENRES_002")
            .IsUnique();
    }
}