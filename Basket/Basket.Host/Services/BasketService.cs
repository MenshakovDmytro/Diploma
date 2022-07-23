using Basket.Host.Data;
using Basket.Host.Models.Dtos;
using Basket.Host.Models.Responses;
using Basket.Host.Repositories.Interfaces;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ILogger<BasketService> _logger;
    private readonly ICacheRepository _cacheRepository;
    private readonly IMapper _mapper;

    public BasketService(
        ILogger<BasketService> logger,
        ICacheRepository cacheRepository,
        IMapper mapper)
    {
        _logger = logger;
        _cacheRepository = cacheRepository;
        _mapper = mapper;
    }

    public async Task<CustomerBasketDto> GetBasket(string id)
    {
        var result = await _cacheRepository.GetAsync(id);
        var basket = _mapper.Map<CustomerBasketDto>(result);
        _logger.LogInformation($"GetBasket in service returned {basket}");

        return basket;
    }

    public async Task<AddItemResponse> AddItemToBasket(string id, BasketItem basketItem)
    {
        var basket = await _cacheRepository.GetAsync(id);

        if (basket is not null)
        {
            if (basket.Items.Where(w => w.Id == basketItem.Id).Count() == 1)
            {
                var item = basket.Items.Where(x => x.Id == basketItem.Id).FirstOrDefault();
                switch (item)
                {
                    case BasketItem:
                        item.Quantity = ++item.Quantity;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                basket.Items.Add(basketItem);
            }
        }
        else
        {
            basket = new CustomerBasket
            {
                Items = new List<BasketItem>() { basketItem }
            };
        }

        var result = await _cacheRepository.AddOrUpdateAsync(id, basket);
        _logger.LogInformation($"AddItemToBasket in service returned {result}");

        return new AddItemResponse()
        {
            Result = result
        };
    }

    public async Task<RemoveFromBasketResponse> RemoveItemFromBasket(string id, int itemId)
    {
        var basket = await _cacheRepository.GetAsync(id);
        var result = false;

        if (basket is not null)
        {
            var basketItem = basket.Items.FirstOrDefault(f => f.Id == itemId);

            if (basketItem is not null)
            {
                result = basket.Items.Remove(basketItem);
                await _cacheRepository.AddOrUpdateAsync(id, basket);
            }
        }

        return new RemoveFromBasketResponse()
        {
            Result = result
        };
    }

    public async Task<DeleteBasketResponse> DeleteAsync(string id)
    {
        var result = await _cacheRepository.DeleteAsync(id);
        _logger.LogInformation($"DeleteAsync in service returned {result}");

        return new DeleteBasketResponse()
        {
            Result = result
        };
    }

    public async Task<UpdateQuantityResponse> UpdateQuantity(string id, Dictionary<int, int> quantites)
    {
        var result = false;
        var basket = await _cacheRepository.GetAsync(id);

        if (basket is not null)
        {
            foreach (var item in quantites)
            {
                var basketItem = basket.Items.FirstOrDefault(f => f.Id == item.Key);
                if (basketItem is not null)
                {
                    basketItem.Quantity = item.Value;
                }
            }

            result = await _cacheRepository.AddOrUpdateAsync(id, basket);
        }

        _logger.LogInformation($"UpdateQuantity in service returned {result}");

        return new UpdateQuantityResponse()
        {
            Result = result
        };
    }
}