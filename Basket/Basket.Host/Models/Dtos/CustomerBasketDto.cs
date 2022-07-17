namespace Basket.Host.Models.Dtos;

public class CustomerBasketDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
}