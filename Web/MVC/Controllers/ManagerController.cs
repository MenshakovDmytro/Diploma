using MVC.Services.Interfaces;
using MVC.ViewModels.ManagerViewModels;

namespace MVC.Controllers;

public class ManagerController : Controller
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    public async Task<IActionResult> ProductsInfo()
    {
        var vm = new CatalogItemListViewModel();
        var items = await _managerService.GetCatalogItems();
        if (items == null)
        {
            return View("Error");
        }

        vm.CatalogItems.AddRange(items.Data);
        return View(vm);
    }

    public async Task<IActionResult> EditItemPage(int id)
    {
        var catalogItem = await _managerService.GetCatalogItem(id);
        if (catalogItem == null)
        {
            return View("Error");
        }

        var vm = new EditItemViewModel
        {
            CatalogItem = catalogItem.Item,
            Categories = await _managerService.GetMechanicsSelectedList(),
            Mechanics = await _managerService.GetCategoriesSelectedList(),
        };

        return View(vm);
    }

    public async Task<IActionResult> EditItem(int id, string name, string description, decimal price, int categoryId, int mechanicId)
    {
        var result = await _managerService.UpdateItem(id, name, description, price, categoryId, mechanicId);

        return Redirect("~/");
    }


    public async Task<IActionResult> RemoveItem(int id)
    {
        var result = await _managerService.RemoveItem(id);
        return Redirect("~/");
    }
}