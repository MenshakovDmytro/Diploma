using Marketing.Host.Data;
using Marketing.Host.Data.Entities;

namespace Marketing.Host.Repositories.Interfaces;

public interface IMarketingItemRepository
{
    Task<int?> AddAsync(int productId, string userId, string username, string comment, int rating);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, int productId, string userId, string username, string comment, int rating);
    Task<ItemsList<MarketingItem>> GetItemsAsync(int productId);
}