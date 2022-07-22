using Marketing.Host.Data.Entities;

namespace Marketing.Host.Data.EntityConfigurations;

public class MarketingItemEntityTypeConfiguration
    : IEntityTypeConfiguration<MarketingItem>
{
    public void Configure(EntityTypeBuilder<MarketingItem> builder)
    {
        builder.ToTable("Marketing");

        builder.Property(mi => mi.Id)
            .UseHiLo("marketing_hilo")
            .IsRequired();

        builder.Property(mi => mi.ProductId)
            .IsRequired();

        builder.Property(mi => mi.UserId)
           .IsRequired()
           .HasMaxLength(10);

        builder.Property(mi => mi.Username)
            .IsRequired(true)
            .HasMaxLength(30);

        builder.Property(mi => mi.Comment)
            .IsRequired(true);

        builder.Property(mi => mi.Rating)
            .IsRequired(true);
    }
}