namespace MVC.ViewComponents;

using MVC.Services.Interfaces;
using MVC.ViewModels.MarketingViewModels;

public class MarketingList : ViewComponent
{
    private readonly IMarketingService _marketingService;

    public MarketingList(IMarketingService marketingService)
    {
        _marketingService = marketingService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var vm = new MarketingViewModel
        {
            ProductId = id
        };

        var marketingItem = await _marketingService.GetReviews(id);
        vm.MarketingItems.AddRange(marketingItem.Data);

        return View(vm);
    }
}