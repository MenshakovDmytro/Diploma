using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Enums;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogItemRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogCategoryId = catalogCategoryId,
            CatalogMechanicId = catalogMechanicId,
            Description = description,
            Name = name,
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

    public async Task<int?> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId)
    {
        var item = await _dbContext.CatalogItems
            .FirstOrDefaultAsync(f => f.Id == id);

        if (item is not null)
        {
            item.CatalogCategoryId = catalogCategoryId;
            item.CatalogMechanicId = catalogMechanicId;
            item.Description = description;
            item.Name = name;
            item.Price = price;

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
            case SortType.PriceAscending:
                query = query.OrderBy(o => o.Price);
                break;
            case SortType.PriceDescending:
                query = query.OrderByDescending(o => o.Price);
                break;
            case SortType.NameDescending:
                query = query.OrderByDescending(o => o.Name);
                break;
            default:
                query = query.OrderBy(o => o.Name);
                break;
        }

        var itemsOnPage = await query
           .Include(i => i.CatalogCategory)
           .Include(i => i.CatalogMechanic)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync();

        return new PaginatedItems<CatalogItem>()
        {
            TotalCount = totalItems,
            Data = itemsOnPage
        };
    }

    public async Task<ItemsList<CatalogItem>> GetItemsAsync()
    {
        var items = await _dbContext.CatalogItems
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogMechanic)
            .ToListAsync();

        return new ItemsList<CatalogItem>()
        {
            TotalCount = items.Count,
            Data = items
        };
    }

    public async Task<CatalogItem?> GetItemAsync(int id)
    {
        var item = await _dbContext.CatalogItems
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogMechanic)
            .FirstOrDefaultAsync(f => f.Id == id);

        return item;
    }
}