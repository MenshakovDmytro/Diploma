using Marketing.Host.Data;
using Marketing.Host.Data.Entities;
using Marketing.Host.Repositories.Interfaces;

namespace Marketing.Host.Repositories;

public class MarketingItemRepository : IMarketingItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MarketingItemRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int?> AddAsync(int productId, string userId, string username, string comment, int rating)
    {
        var item = await _dbContext.AddAsync(new MarketingItem
        {
            ProductId = productId,
            UserId = userId,
            Username = username,
            Comment = comment,
            Rating = rating
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<ItemsList<MarketingItem>> GetItemsAsync(int productId)
    {
        var items = await _dbContext.MarketingItems
            .Where(w => w.ProductId == productId)
            .ToListAsync();

        return new ItemsList<MarketingItem>() { TotalCount = items.Count, Data = items };
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var item = await _dbContext.MarketingItems
            .FirstOrDefaultAsync(f => f.Id == id);

        var result = _dbContext.Remove(item!);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int?> UpdateAsync(int id, int productId, string userId, string username, string comment, int rating)
    {
        var item = await _dbContext.MarketingItems
            .FirstOrDefaultAsync(f => f.Id == id);

        if (item is not null)
        {
            item.ProductId = productId;
            item.UserId = userId;
            item.Username = username;
            item.Comment = comment;
            item.Rating = rating;

            item = _dbContext.Update(item).Entity;
            await _dbContext.SaveChangesAsync();
        }

        return item!.Id;
    }
}