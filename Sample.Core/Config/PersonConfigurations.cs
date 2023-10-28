using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Models;

namespace Sample.Core.Config;
internal class PersonConfigurations : IEntityTypeConfiguration<PersonModel>
{
    public void Configure(EntityTypeBuilder<PersonModel> builder)
    {
        _ = builder.ToTable("PEOPLE");

        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        _ = builder.HasIndex(x => x.Id, "IDX_PEOPLE_001")
            .IsUnique();

        _ = builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnType("varchar(45)")
            .HasColumnName("FIRST_NAME");

        _ = builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnType("varchar(45)")
            .HasColumnName("LAST_NAME");

        _ = builder.Ignore(x => x.FullName);
    }
}
