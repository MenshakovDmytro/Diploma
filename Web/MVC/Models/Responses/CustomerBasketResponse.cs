namespace MVC.Models.Responses;

using MVC.ViewModels;

public class CustomerBasketResponse
{
    public string? BuyerId { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}