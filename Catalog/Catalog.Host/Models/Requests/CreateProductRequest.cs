namespace Catalog.Host.Models.Requests;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CatalogMechanicId { get; set; }
    public int CatalogCategoryId { get; set; }
}