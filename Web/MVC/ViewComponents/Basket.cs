using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.BasketViewModels;

namespace MVC.ViewComponents;

public class Basket : ViewComponent
{
    private readonly IBasketService _basketService;

    public Basket(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
    {
        var vm = new BasketComponentViewModel();
        try
        {
            var itemsInBasket = await ItemsInBasketAsync(user);
            vm.ItemsCount = itemsInBasket;
            return View(vm);
        }
        catch
        {
            ViewBag.IsBasketInoperative = true;
        }

        return View(vm);
    }
    private async Task<int> ItemsInBasketAsync(ApplicationUser user)
    {
        var basket = await _basketService.GetBasket(user);
        return basket.Items.Count;
    }
}