using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogMechanicRepository : ICatalogMechanicRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogMechanicRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
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

        return new ItemsList<CatalogMechanic>()
        {
            TotalCount = types.Count,
            Data = types
        };
    }

    public async Task<CatalogMechanic?> GetMechanicAsync(int id)
    {
        var type = await _dbContext.CatalogMechanics
            .FirstOrDefaultAsync(f => f.Id == id);

        return type;
    }
}