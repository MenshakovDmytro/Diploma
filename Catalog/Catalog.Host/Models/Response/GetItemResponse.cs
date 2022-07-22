using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Models.Response;

public class GetItemResponse
{
    public CatalogItemDto CatalogItem { get; set; } = null!;
}