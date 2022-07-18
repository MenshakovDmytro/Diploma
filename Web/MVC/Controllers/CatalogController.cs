using MVC.Services.Interfaces;
using MVC.ViewModels.CatalogViewModels;
using MVC.ViewModels.Pagination;

namespace MVC.Controllers;

public class CatalogController : Controller
{
    private  readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<IActionResult> Index(int? categoryFilterApplied, int? mechanicFilterApplied, int? sortApplied, int? page, int? itemsPage)
    {   
        page ??= 0;
        itemsPage ??= 6;
        sortApplied ??= 0;
        
        var catalog = await _catalogService.GetCatalogItems(page.Value, itemsPage.Value, categoryFilterApplied, mechanicFilterApplied, sortApplied.Value);
        if (catalog == null)
        {
            return View("Error");
        }
        var info = new PaginationInfo()
        {
            ActualPage = page.Value,
            ItemsPerPage = catalog.Data.Count,
            TotalItems = catalog.Count,
            TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsPage.Value),
            CategoryFilter = categoryFilterApplied,
            MechanicFilter = mechanicFilterApplied,
            Sort = sortApplied
        };
        var vm = new IndexViewModel()
        {
            CatalogItems = catalog.Data,
            Categories = await _catalogService.GetCategories(),
            Mechanics = await _catalogService.GetMechanics(),
            Sort = _catalogService.GetSortTypes(),
            PaginationInfo = info
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

        return View(vm);
    }

    public async Task<IActionResult> ProductPageInfo(int id)
    {
        var product = await _catalogService.GetItem(id);
        if (product == null)
        {
            return View("Error");
        }

        return View(product);
    }
}