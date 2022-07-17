using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Enums;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int catalogCategoryId, int catalogMechanicId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogCategoryId = catalogCategoryId,
            CatalogMechanicId = catalogMechanicId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var item = await _dbContext.CatalogItems
            .FirstOrDefaultAsync(f => f.Id == id);

        var result = _dbContext.Remove(item!);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> UpdateAsync(int id, string name, string description, decimal price, int availableStock, int catalogCategoryId, int catalogMechanicId, string pictureFileName)
    {
        var item = await _dbContext.CatalogItems
            .FirstOrDefaultAsync(f => f.Id == id);

        if (item is not null)
        {
            item.CatalogCategoryId = catalogCategoryId;
            item.CatalogMechanicId = catalogMechanicId;
            item.Description = description;
            item.Name = name;
            item.PictureFileName = pictureFileName;
            item.Price = price;
            item.AvailableStock = availableStock;

            item = _dbContext.Update(item).Entity;
            await _dbContext.SaveChangesAsync();
        }

        return item!.Id;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? categoryFilter, int? mechanicFilter, int sort)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        if (mechanicFilter.HasValue)
        {
            query = query.Where(w => w.CatalogMechanicId == mechanicFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        switch ((SortType)sort)
        {
            case SortType.Ascending:
                query = query.OrderBy(o => o.Price);
                break;
            case SortType.Descending:
                query = query.OrderByDescending(o => o.Price);
                break;
            default:
                query = query.OrderBy(c => c.Name);
                break;
        }

        var itemsOnPage = await query
           .Include(i => i.CatalogCategory)
           .Include(i => i.CatalogMechanic)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<ItemsList<CatalogItem>> GetItemsAsync()
    {
        var items = await _dbContext.CatalogItems
            .ToListAsync();

        return new ItemsList<CatalogItem>() { TotalCount = items.Count, Data = items };
    }
}