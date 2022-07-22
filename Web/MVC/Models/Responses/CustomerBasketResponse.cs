using MVC.ViewModels;

namespace MVC.Models.Responses;

public class CustomerBasketResponse
{
    public string? BuyerId { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}