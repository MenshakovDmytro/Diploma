using Basket.Host.Data;

namespace Basket.Host.Repositories.Interfaces;

public interface ICacheRepository
{
    Task<CustomerBasket> GetAsync(string customerId);
    Task<bool> AddOrUpdateAsync(string customerId, CustomerBasket customerBasket);
    Task<bool> DeleteAsync(string customerId);
}