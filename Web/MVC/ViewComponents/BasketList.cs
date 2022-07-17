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
            var vm = new CustomerBasket();
            try
            {
                vm = await GetItemsAsync(user);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.BasketInoperativeMsg = $"Basket Service is inoperative, please try later on. ({ex.GetType().Name} - {ex.Message}))";
            }

            return View(vm);
        }

        private Task<CustomerBasket> GetItemsAsync(ApplicationUser user) => _basketService.GetBasket(user);
    }
}