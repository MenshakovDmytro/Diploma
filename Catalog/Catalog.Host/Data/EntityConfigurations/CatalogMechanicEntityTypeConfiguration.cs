using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogMechanicEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogMechanic>
{
    public void Configure(EntityTypeBuilder<CatalogMechanic> builder)
    {
        builder.ToTable("CatalogMechanic");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_mechanic_hilo")
            .IsRequired();

        builder.Property(cb => cb.Mechanic)
            .IsRequired()
            .HasMaxLength(20);
    }
}