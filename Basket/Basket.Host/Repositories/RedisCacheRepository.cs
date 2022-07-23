using StackExchange.Redis;
using Basket.Host.Repositories.Interfaces;
using Basket.Host.Data;

namespace Basket.Host.Repositories;

public class RedisCacheRepository : ICacheRepository
{
    private readonly ILogger<RedisCacheRepository> _logger;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisCacheRepository(
        ILogger<RedisCacheRepository> logger,
        IJsonSerializer jsonSerializer,
        ConnectionMultiplexer redis)
    {
        _logger = logger;
        _jsonSerializer = jsonSerializer;
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task<CustomerBasket> GetAsync(string id)
    {
        var basket = await _database.StringGetAsync(id);

        if (basket.HasValue)
        {
            _logger.LogInformation($"Basket for customer with id {id} has value");
        }
        else
        {
            _logger.LogInformation($"Basket for customer with id {id} contains no value");
        }

        return basket.HasValue ?
            _jsonSerializer.Deserialize<CustomerBasket>(basket)
            : default(CustomerBasket) !;
    }

    public async Task<bool> AddOrUpdateAsync(string customerId, CustomerBasket customerBasket)
    {
        var basket = _jsonSerializer.Serialize(customerBasket);
        var result = await _database.StringSetAsync(customerId, basket);

        if (result)
        {
            _logger.LogInformation($"Value for key {customerId} cached");
        }
        else
        {
            _logger.LogInformation($"Value for key {customerId} was not cached");
        }

        return result;
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
        var result = await _database.KeyDeleteAsync(customerId);
        _logger.LogInformation($"Cached value for key {customerId} was deleted");

        return result;
    }
}