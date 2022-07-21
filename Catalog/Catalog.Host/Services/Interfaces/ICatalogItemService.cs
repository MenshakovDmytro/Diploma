using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<ItemsListResponse<CatalogItemDto>> GetItemsAsync();
    Task<CatalogItemDto?> GetItemAsync(int id);
}