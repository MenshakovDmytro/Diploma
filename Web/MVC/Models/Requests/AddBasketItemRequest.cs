namespace MVC.Models.Requests;

using MVC.ViewModels;

public class AddBasketItemRequest
{
    public string Id { get; set; } = null!;
    public BasketItem BasketItem { get; set; } = null!;
}