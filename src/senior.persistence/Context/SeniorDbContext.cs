using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using senior.domain.Entites;
using senior.persistence.Mappings;

namespace senior.persistence.Context;

public class SeniorDbContext : DbContext
{
    public SeniorDbContext() { }
    public SeniorDbContext(DbContextOptions<SeniorDbContext> options) : base(options) { }

	public DbSet<Locality> Localitys { get; set; }
	public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.
                UseSqlServer("Server=SILVERIOBRCNBK\\SQLEXPRESS;Database=Senior;Integrated Security=SSPI;TrustServerCertificate=True;", p => 
                    p.MigrationsHistoryTable("Senior_Migrations"))
                .LogTo(Console.WriteLine, LogLevel.Warning);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LocalityMap());
    }
}
