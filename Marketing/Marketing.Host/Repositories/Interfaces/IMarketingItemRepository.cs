namespace Marketing.Host.Repositories.Interfaces;

using Marketing.Host.Data.Entities;
using Marketing.Host.Models.Responses;

public interface IMarketingItemRepository
{
    Task<int?> AddAsync(int productId, string userId, string username, string comment, int rating);
    Task<int?> RemoveAsync(int id);
    Task<int?> RemoveByUserId(string userId);
    Task<int?> UpdateAsync(int id, int productId, string userId, string username, string comment, int rating);
    Task<ItemsListResponse<MarketingItem>> GetItemsAsync(int productId);
}