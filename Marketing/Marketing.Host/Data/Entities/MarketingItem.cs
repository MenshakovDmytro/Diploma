namespace Marketing.Host.Data.Entities;

public class MarketingItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}