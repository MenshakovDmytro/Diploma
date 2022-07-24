namespace Basket.Host.Repositories.Interfaces;

using Basket.Host.Data;

public interface ICacheRepository
{
    Task<CustomerBasket> GetAsync(string customerId);
    Task<bool> AddOrUpdateAsync(string customerId, CustomerBasket customerBasket);
    Task<bool> DeleteAsync(string customerId);
}