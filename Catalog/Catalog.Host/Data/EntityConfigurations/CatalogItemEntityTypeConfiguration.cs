using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogItemEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("Catalog");

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(ci => ci.Price)
            .IsRequired(true);

        builder.Property(ci => ci.PictureFileName)
            .IsRequired(true);

        builder.HasOne(ci => ci.CatalogCategory)
            .WithMany()
            .HasForeignKey(ci => ci.CatalogCategoryId);

        builder.HasOne(ci => ci.CatalogMechanic)
            .WithMany()
            .HasForeignKey(ci => ci.CatalogMechanicId);
    }
}