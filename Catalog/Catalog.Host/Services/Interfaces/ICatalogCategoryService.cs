using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCategoryService
{
    Task<int?> AddAsync(string name);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogCategoryDto>> GetCategoriesAsync();
}