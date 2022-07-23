namespace MVC.ViewModels;

public class CustomerBasket
{
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    public decimal Total()
    {
        return Math.Round(Items.Sum(x => x.Price * x.Quantity), 2);
    }
}