using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using senior.domain.Entites;

namespace senior.persistence.Mappings;

public class LocalityMap : IEntityTypeConfiguration<Locality>
{
    public void Configure(EntityTypeBuilder<Locality> builder)
    {
        builder.ToTable("locality");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("CHAR")
            .HasMaxLength(7);

        builder.OwnsOne(x => x.City, tf =>
        {
            tf.Property(t => t.State)
                .HasColumnType("CHAR")
                .HasMaxLength(2)
                .HasColumnName("State")
                .IsRequired();

            tf.HasIndex(t => t.State).HasDatabaseName("IX_Locality_State");
        });

        builder.OwnsOne(x => x.City, tf =>
        {
            tf.Property(t => t.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .HasColumnName("Name")
                .IsRequired();

            tf.HasIndex(t => t.Name).HasDatabaseName("IX_Locality_Name");
        });
    }
}
