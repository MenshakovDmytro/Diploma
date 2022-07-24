namespace Catalog.Host.Repositories.Interfaces;

using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

public interface ICatalogCategoryRepository
{
    Task<int?> AddAsync(string name);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string name);
    Task<ItemsList<CatalogCategory>> GetCategoriesAsync();
    Task<CatalogCategory?> GetCategoryAsync(int id);
}