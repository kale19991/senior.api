using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using senior.domain.Entites;

namespace senior.persistence.Mappings;

public class LocalityMap : IEntityTypeConfiguration<Locality>
{
    public void Configure(EntityTypeBuilder<Locality> builder)
    {
        builder.ToTable("locality");

        builder.HasKey(t => t.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("CHAR")
            .HasMaxLength(7)
            .IsRequired();

        //builder.OwnsOne(x => x.Id, tf =>
        //{
        //    tf.Property(t => t.Value)
        //      .HasColumnName("Id")
        //      .HasColumnType("CHAR")
        //      .HasMaxLength(7);

        //    tf.HasIndex(t => t.Value).HasDatabaseName("IX_Locality_Id");
        //});


        builder.OwnsOne(x => x.State, tf =>
        {
            tf.Property(t => t.Value)
              .HasColumnName("State")
              .HasColumnType("CHAR")
              .HasMaxLength(2)
              .IsRequired();

            tf.HasIndex(t => t.Value).HasDatabaseName("IX_Locality_State");
        });

        builder.OwnsOne(x => x.City, tf =>
        {
            tf.Property(t => t.Value)
              .HasColumnName("City")
              .HasColumnType("NVARCHAR")
              .HasMaxLength(80)
              .IsRequired();

            tf.HasIndex(t => t.Value).HasDatabaseName("IX_Locality_City");
        });
    }
}
