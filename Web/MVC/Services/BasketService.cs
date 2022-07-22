using MVC.Models.Requests;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class BasketService : IBasketService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;

    public BasketService(IHttpClientService httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<CustomerBasket> GetBasket(ApplicationUser user)
    {
        var result = await _httpClient.SendAsync<CustomerBasket, GetBasketRequest>($"{_settings.Value.BasketUrl}/GetBasket",
        HttpMethod.Post,
        new GetBasketRequest()
        {
            Id = user.Id
        });

        return result == null ?
            new CustomerBasket()
            : result;
    }

    public async Task<AddItemResponse> AddToBasket(ApplicationUser user, BasketItem basketItem)
    {
        var result = await _httpClient.SendAsync<AddItemResponse, AddItemRequest>($"{_settings.Value.BasketUrl}/AddToBasket",
        HttpMethod.Post,
        new AddItemRequest()
        {
            Id = user.Id,
            BasketItem = basketItem
        });

        return result;
    }
    public async Task<RemoveFromBasketResponse> RemoveFromBasket(ApplicationUser user, int itemId)
    {
        var result = await _httpClient.SendAsync<RemoveFromBasketResponse, RemoveFromBasketRequest>($"{_settings.Value.BasketUrl}/RemoveFromBasket",
        HttpMethod.Post,
        new RemoveFromBasketRequest()
        {
            Id = user.Id,
            ItemId = itemId
        });

        return result;
    }


    public async Task<DeleteBasketResponse> DeleteBasket(ApplicationUser user)
    {
        var result = await _httpClient.SendAsync<DeleteBasketResponse, DeleteBasketRequest>($"{_settings.Value.BasketUrl}/DeleteBasket",
        HttpMethod.Post,
        new DeleteBasketRequest()
        {
            Id = user.Id
        });

        return result;
    }

    public async Task<UpdateQuantityResponse> SetQuantities(ApplicationUser user, Dictionary<int, int> quantities)
    {
        var result = await _httpClient.SendAsync<UpdateQuantityResponse, UpdateQuantityRequest>($"{_settings.Value.BasketUrl}/UpdateQuantity",
        HttpMethod.Post,
        new UpdateQuantityRequest()
        {
            Id = user.Id,
            Quantities = quantities
        });

        return result;
    }
}