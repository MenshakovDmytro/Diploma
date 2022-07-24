namespace Basket.Host.Services.Interfaces;

using Basket.Host.Data;
using Basket.Host.Models.Dtos;
using Basket.Host.Models.Responses;

public interface IBasketService
{
    Task<CustomerBasketDto> GetBasket(string id);
    Task<AddItemResponse> AddItemToBasket(string id, BasketItem basketItem);
    Task<RemoveFromBasketResponse> RemoveItemFromBasket(string id, int itemId);
    Task<DeleteBasketResponse> DeleteAsync(string id);
    Task<UpdateQuantityResponse> UpdateQuantity(string id, Dictionary<int, int> quantities);
}