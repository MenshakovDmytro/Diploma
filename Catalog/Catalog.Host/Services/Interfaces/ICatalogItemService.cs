namespace Catalog.Host.Services.Interfaces;

using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

public interface ICatalogItemService
{
    Task<AddResponse<int?>> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<RemoveItemResponse<int?>> RemoveAsync(int id);
    Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<ItemsListResponse<CatalogItemDto>> GetItemsAsync();
    Task<GetItemResponse<CatalogItemDto>> GetItemAsync(int id);
}