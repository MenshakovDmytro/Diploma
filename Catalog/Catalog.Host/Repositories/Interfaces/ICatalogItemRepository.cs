namespace Catalog.Host.Repositories.Interfaces;

using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

public interface ICatalogItemRepository
{
    Task<int?> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId, string pictureFileName);
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? catelogFilter, int? mechanicFilter, int sort);
    Task<ItemsList<CatalogItem>> GetItemsAsync();
    Task<CatalogItem?> GetItemAsync(int id);
}