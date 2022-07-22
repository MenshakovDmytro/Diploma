using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCategoryService
{
    Task<AddCategoryResponse<int?>> AddAsync(string name);
    Task<RemoveCategoryResponse<int?>> RemoveAsync(int id);
    Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogCategoryDto>> GetCategoriesAsync();
}