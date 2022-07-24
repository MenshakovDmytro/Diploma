namespace Marketing.Host.Models.Dtos;

public class MarketingItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}