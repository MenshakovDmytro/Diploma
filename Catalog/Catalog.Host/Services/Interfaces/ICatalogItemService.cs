using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<AddItemResponse<int?>> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId);
    Task<RemoveItemResponse<int?>> RemoveAsync(int id);
    Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId);
    Task<ItemsListResponse<CatalogItemDto>> GetItemsAsync();
    Task<GetItemResponse<CatalogItemDto>> GetItemAsync(int id);
}