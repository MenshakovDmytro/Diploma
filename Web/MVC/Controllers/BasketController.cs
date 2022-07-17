using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly ICatalogService _catalogService;
    private readonly IIdentityParser<ApplicationUser> _appUserParser;

    public BasketController(IBasketService basketService, ICatalogService catalogService, IIdentityParser<ApplicationUser> appUserParser)
    {
        _basketService = basketService;
        _catalogService = catalogService;
        _appUserParser = appUserParser;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var user = _appUserParser.Parse(HttpContext.User);
            var vm = await _basketService.GetBasket(user);

            return View(vm);
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }

        return View();
    }

    public async Task<IActionResult> UpdateQuantities(Dictionary<int, int> quantities)
    {
        try
        {
            var user = _appUserParser.Parse(HttpContext.User);
            var basket = await _basketService.SetQuantities(user, quantities);
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }

        return View("Index");
    }

    public async Task<IActionResult> AddToBasket(int id, string name, string price, string pictureUrl)
    {
        try
        {
            if (id != 0)
            {
                var user = _appUserParser.Parse(HttpContext.User);
                var unitPrice = 0M;
                decimal.TryParse(price, out unitPrice);
                var basketItem = new BasketItem()
                {
                    Id = id,
                    Name = name,
                    Price = unitPrice,
                    PictureUrl = pictureUrl,
                    Quantity = 1
                };

                await _basketService.AddToBasket(user, basketItem);
            }

            return RedirectToAction("Index", "Catalog");
        }
        catch (Exception ex)
        {          
            HandleException(ex);
        }

        return RedirectToAction("Index", "Catalog", new { errorMsg = ViewBag.BasketInoperativeMsg });
    }

    public async Task<IActionResult> RemoveFromBasket(int id)
    {
        try
        {
            if (id != 0)
            {
                var user = _appUserParser.Parse(HttpContext.User);
                await _basketService.RemoveFromBasket(user, id);
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }

        return View("Index");
    }

    private void HandleException(Exception ex)
    {
        ViewBag.BasketInoperativeMsg = $"Basket Service is inoperative {ex.GetType().Name} - {ex.Message}";
    }
}