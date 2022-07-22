using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.ViewComponents
{
    public class BasketList : ViewComponent
    {
        private readonly IBasketService _basketService;

        public BasketList(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = await _basketService.GetBasket(user);
            return View(vm);
        }
    }
}