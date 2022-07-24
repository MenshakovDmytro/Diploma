namespace Catalog.Host.Services.Interfaces;

using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

public interface ICatalogCategoryService
{
    Task<AddResponse<int?>> AddAsync(string name);
    Task<RemoveCategoryResponse<int?>> RemoveAsync(int id);
    Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogCategoryDto>> GetCategoriesAsync();
    Task<GetItemResponse<CatalogCategoryDto>> GetCategoryAsync(int id);
}