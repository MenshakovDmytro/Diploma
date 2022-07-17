using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogMechanicRepository : ICatalogMechanicRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogCategoryRepository> _logger;

    public CatalogMechanicRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogCategoryRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(string name)
    {
        var mechanic = await _dbContext.AddAsync(new CatalogMechanic()
        {
            Mechanic = name
        });

        await _dbContext.SaveChangesAsync();

        return mechanic.Entity.Id;
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var mechanic = await _dbContext.CatalogMechanics
            .FirstOrDefaultAsync(f => f.Id == id);

        var result = _dbContext.Remove(mechanic!);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> UpdateAsync(int id, string name)
    {
        var mechanic = await _dbContext.CatalogMechanics
            .FirstOrDefaultAsync(f => f.Id == id);

        if (mechanic is not null)
        {
            mechanic.Mechanic = name;

            mechanic = _dbContext.Update(mechanic).Entity;
            await _dbContext.SaveChangesAsync();
        }

        return mechanic!.Id;
    }

    public async Task<ItemsList<CatalogMechanic>> GetMechanicsAsync()
    {
        var types = await _dbContext.CatalogMechanics
            .ToListAsync();

        return new ItemsList<CatalogMechanic>() { TotalCount = types.Count, Data = types };
    }
}