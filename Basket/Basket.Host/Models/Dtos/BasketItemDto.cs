namespace Basket.Host.Models.Dtos;

public class BasketItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = null!;
    public int Quantity { get; set; }
}