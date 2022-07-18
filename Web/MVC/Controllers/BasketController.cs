using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IIdentityParser<ApplicationUser> _appUserParser;

    public BasketController(IBasketService basketService, IIdentityParser<ApplicationUser> appUserParser)
    {
        _basketService = basketService;
        _appUserParser = appUserParser;
    }

    public async Task<IActionResult> Index()
    {
        var user = GetCurrentUser();
        var basket = await _basketService.GetBasket(user);
        if (basket == null)
        {
            return View("Error");
        }

        return View(basket);
    }

    public async Task<IActionResult> UpdateQuantities(Dictionary<int, int> quantities)
    {
        var user = GetCurrentUser();
        var basket = await _basketService.SetQuantities(user, quantities);
        if (basket == null)
        {
            return View("Error");
        }

        return View("Index");
    }

    public async Task<IActionResult> AddToBasket(int id, string name, string price, string pictureUrl)
    {
        var user = GetCurrentUser();
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

        var result = await _basketService.AddToBasket(user, basketItem);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("Index", "Catalog");
    }

    public async Task<IActionResult> RemoveFromBasket(int id)
    {
        var user = GetCurrentUser();
        var result = await _basketService.RemoveFromBasket(user, id);
        if (result == null)
        {
            return View("Error");
        }

        return View("Index");
    }

    private ApplicationUser GetCurrentUser() => _appUserParser.Parse(HttpContext.User);
}