using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Controllers;

public class MarketingController : Controller
{
    private readonly IMarketingService _marketingService;
    private readonly IIdentityParser<ApplicationUser> _appUserParser;

    public MarketingController(
        IMarketingService marketingService,
        IIdentityParser<ApplicationUser> appUserParser)
    {
        _marketingService = marketingService;
        _appUserParser = appUserParser;
    }

    public async Task<IActionResult> AddReview(int productId, string comment, int rating)
    {
        var user = _appUserParser.Parse(HttpContext.User);
        var result = await _marketingService.AddReview(productId, user, comment, rating);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("ProductPageInfo", "Catalog", new { id = productId });
    }

    public async Task<IActionResult> RemoveReview(int productId)
    {
        var user = _appUserParser.Parse(HttpContext.User);
        var result = await _marketingService.RemoveReview(user.Id);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("ProductPageInfo", "Catalog", new { id = productId });
    }
}