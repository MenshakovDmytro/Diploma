namespace Marketing.Host.Data.Entities;

public class MarketingItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}