namespace MVC.ViewModels;

public record CatalogItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = null!;
    public CatalogMechanic CatalogType { get; set; } = null!;
    public CatalogCategory CatalogBrand { get; set; } = null!;
}