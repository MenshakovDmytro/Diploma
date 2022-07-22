using Marketing.Host.Data.Entities;
using Marketing.Host.Data.EntityConfigurations;

namespace Marketing.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<MarketingItem> MarketingItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MarketingItemEntityTypeConfiguration());
    }
}