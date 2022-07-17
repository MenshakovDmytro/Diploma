using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogCategoryRepository : ICatalogCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogCategoryRepository> _logger;

    public CatalogCategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogCategoryRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(string name)
    {
        var category = await _dbContext.AddAsync(new CatalogCategory()
        {
            Category = name
        });

        await _dbContext.SaveChangesAsync();

        return category.Entity.Id;
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var category = await _dbContext.CatalogCategories
            .FirstOrDefaultAsync(f => f.Id == id);

        var result = _dbContext.Remove(category!);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> UpdateAsync(int id, string name)
    {
        var category = await _dbContext.CatalogCategories
            .FirstOrDefaultAsync(f => f.Id == id);

        if (category is not null)
        {
            category.Category = name;

            category = _dbContext.Update(category).Entity;
            await _dbContext.SaveChangesAsync();
        }

        return category!.Id;
    }

    public async Task<ItemsList<CatalogCategory>> GetCategoriesAsync()
    {
        var categories = await _dbContext.CatalogCategories
            .ToListAsync();

        return new ItemsList<CatalogCategory>() { TotalCount = categories.Count, Data = categories };
    }
}