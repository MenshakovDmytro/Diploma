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
        var vm = new BasketViewModel();
        var basket = await _basketService.GetBasket(user);
        vm.ItemsCount = basket.Items.Count;

        return View(vm);
    }
}