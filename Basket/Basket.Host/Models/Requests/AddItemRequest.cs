namespace Basket.Host.Models.Requests;

using Basket.Host.Data;

public class AddItemRequest
{
    public string Id { get; set; } = null!;
    public BasketItem BasketItem { get; set; } = null!;
}