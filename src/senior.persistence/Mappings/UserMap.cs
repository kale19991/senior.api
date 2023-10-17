using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using senior.domain.Entites;

namespace senior.persistence.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(t => t.Id);

        builder
            .Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        builder.OwnsOne(x => x.Email, tf =>
        {
            tf.Property(t => t.Value)
              .HasColumnName("Email")
              .HasColumnType("NVARCHAR")
              .HasMaxLength(200)
              .IsRequired();

            tf.HasIndex(t => t.Value).HasDatabaseName("IX_User_Email").IsUnique();
        });

        builder
            .Property(x => x.PasswordHash)
            .HasColumnName("PasswordHash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250)
            .IsRequired();
    }
}
