namespace MVC.ViewModels.MarketingViewModels;

public class MarketingViewModel
{
    public int ProductId { get; set; }
    public List<MarketingItem> MarketingItems { get; set; } = new List<MarketingItem>();
}