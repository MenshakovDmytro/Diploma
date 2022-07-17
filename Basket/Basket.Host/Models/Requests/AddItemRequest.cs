using Basket.Host.Data;

namespace Basket.Host.Models.Requests;

public class AddItemRequest
{
    public string Id { get; set; } = null!;
    public BasketItem BasketItem { get; set; } = null!;
}