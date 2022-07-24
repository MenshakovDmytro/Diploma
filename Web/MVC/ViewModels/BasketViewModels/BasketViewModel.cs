namespace MVC.ViewModels.BasketViewModels;

public class BasketViewModel
{
    public int ItemsCount { get; set; }
    public string Disabled => (ItemsCount == 0) ? "is-disabled" : string.Empty;
}