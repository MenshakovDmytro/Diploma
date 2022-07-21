namespace Catalog.Host.Data.Entities;

public class CatalogItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CatalogMechanicId { get; set; }
    public CatalogMechanic CatalogMechanic { get; set; } = null!;
    public int CatalogCategoryId { get; set; }
    public CatalogCategory CatalogCategory { get; set; } = null!;
}