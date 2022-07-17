namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = null!;
    public CatalogMechanicDto CatalogMechanic { get; set; } = null!;
    public CatalogCategoryDto CatalogCategory { get; set; } = null!;
    public int AvailableStock { get; set; }
}