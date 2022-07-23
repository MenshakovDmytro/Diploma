namespace Catalog.Host.Models.Requests;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CatalogMechanicId { get; set; }
    public int CatalogCategoryId { get; set; }
}