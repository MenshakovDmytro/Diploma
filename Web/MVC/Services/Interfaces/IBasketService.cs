namespace MVC.Services.Interfaces;

using MVC.Models.Responses;
using MVC.ViewModels;

public interface IBasketService
{
    Task<AddItemResponse<bool>> AddToBasket(ApplicationUser user, BasketItem basketItem);
    Task<RemoveFromBasketResponse> RemoveFromBasket(ApplicationUser user, int itemId);
    Task<CustomerBasket> GetBasket(ApplicationUser user);
    Task<DeleteBasketResponse> DeleteBasket(ApplicationUser user);
    Task<UpdateQuantityResponse> SetQuantities(ApplicationUser user, Dictionary<int, int> quantities);
}