using Basket.Host.Data;

namespace Basket.Host.Models.Requests;

public class RemoveFromBasketRequest
{
    public string Id { get; set; } = null!;
    public int ItemId { get; set; }
}