using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using senior.domain.Entites;

namespace senior.persistence.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(t => t.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150);

        builder.OwnsOne(x => x.Email, tf =>
        {
            tf.Property(t => t.Value)
              .IsRequired()
              .HasColumnName("Email")
              .HasColumnType("NVARCHAR")
              .HasMaxLength(200);

            tf.HasIndex(t => t.Value).HasDatabaseName("IX_User_Email").IsUnique();
        });

        builder
            .Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);        
    }
}
