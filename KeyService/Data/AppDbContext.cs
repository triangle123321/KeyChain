using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    // This creates a "GameKeys" table
    public DbSet<GameKey> GameKeys { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure your entities here
        modelBuilder.Entity<GameKey>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Key).IsRequired().HasMaxLength(500);
            entity.Property(e => e.GameTitle).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Platform).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            // Create an index for faster searches
            entity.HasIndex(e => e.Platform);
            entity.HasIndex(e => e.IsUsed);
        });
    }
}