namespace MVC.Models.Requests;

public class RemoveFromBasketRequest
{
    public string Id { get; set; } = null!;
    public int ItemId { get; set; }
}