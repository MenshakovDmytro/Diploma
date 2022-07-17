using MVC.Models.Responses;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface IBasketService
{
    Task<AddItemResponse> AddToBasket(ApplicationUser user, BasketItem basketItem);
    Task<RemoveFromBasketResponse> RemoveFromBasket(ApplicationUser user, int itemId);
    Task<CustomerBasket> GetBasket(ApplicationUser user);
    Task<DeleteBasketResponse> DeleteBasket(ApplicationUser user);
    Task<UpdateQuantityResponse> SetQuantities(ApplicationUser user, Dictionary<int, int> quantities);
}