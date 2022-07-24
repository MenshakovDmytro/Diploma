namespace MVC.Controllers;

using MVC.Services.Interfaces;
using MVC.ViewModels.ManagerViewModels;

public class ManagerController : Controller
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    public async Task<IActionResult> ItemsInfo()
    {
        var vm = new CatalogItemsListViewModel();
        var items = await _managerService.GetCatalogItems();
        if (items == null)
        {
            return View("Error");
        }

        vm.CatalogItems.AddRange(items.Data.OrderBy(o => o.Name));
        return View(vm);
    }

    public async Task<IActionResult> EditItemPage(int id)
    {
        var catalogItem = await _managerService.GetCatalogItem(id);
        var pictureFileName = Path.GetFileName(catalogItem.Item.PictureUrl);
        if (catalogItem == null)
        {
            return View("Error");
        }

        var vm = new EditItemViewModel
        {
            CatalogItem = catalogItem.Item,
            PictureFileName = pictureFileName,
            Categories = await _managerService.GeеSelectedListCategories(),
            Mechanics = await _managerService.GetSelectedListMechanics()
        };

        return View(vm);
    }

    public async Task<IActionResult> EditItem(int id, string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId)
    {
        var result = await _managerService.UpdateItem(id, name, description, price, pictureFileName, categoryId, mechanicId);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("ItemsInfo");
    }

    public async Task<IActionResult> AddItem(string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId)
    {
        var result = await _managerService.AddItem(name, description, price, pictureFileName, categoryId, mechanicId);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("ItemsInfo");
    }

    public async Task<IActionResult> AddItemPage()
    {
        var vm = new AddItemViewModel
        {
            Categories = await _managerService.GeеSelectedListCategories(),
            Mechanics = await _managerService.GetSelectedListMechanics()
        };

        return View(vm);
    }

    public async Task<IActionResult> RemoveItem(int id)
    {
        var result = await _managerService.RemoveItem(id);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("ItemsInfo");
    }

    public async Task<IActionResult> CategoriesInfo()
    {
        var vm = new CatalogCategoriesListViewModel();
        var categories = await _managerService.GetCategories();
        if (categories == null)
        {
            return View("Error");
        }

        vm.CatalogCategories.AddRange(categories.Data.OrderBy(o => o.Category));
        return View(vm);
    }

    public async Task<IActionResult> EditCategoryPage(int id)
    {
        var catalogCategory = await _managerService.GetCategory(id);
        if (catalogCategory == null)
        {
            return View("Error");
        }

        var vm = new EditCategoryViewModel
        {
            CatalogCategory = catalogCategory.Item
        };

        return View(vm);
    }

    public async Task<IActionResult> EditCategory(int id, string category)
    {
        var result = await _managerService.UpdateCategory(id, category);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("CategoriesInfo");
    }

    public async Task<IActionResult> AddCategory(string category)
    {
        var result = await _managerService.AddCategory(category);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("CategoriesInfo");
    }

    public IActionResult AddCategoryPage() => View();

    public async Task<IActionResult> RemoveCategory(int id)
    {
        var result = await _managerService.RemoveCategory(id);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("CategoriesInfo");
    }

    public async Task<IActionResult> MechanicsInfo()
    {
        var vm = new CatalogMechanicsListViewModel();
        var mechanics = await _managerService.GetMechanics();
        if (mechanics == null)
        {
            return View("Error");
        }

        vm.CatalogMechanics.AddRange(mechanics.Data.OrderBy(o => o.Mechanic));
        return View(vm);
    }

    public async Task<IActionResult> EditMechanicPage(int id)
    {
        var mechanicCategory = await _managerService.GetMechanic(id);
        if (mechanicCategory == null)
        {
            return View("Error");
        }

        var vm = new EditMechanicViewModel
        {
            CatalogMechanic = mechanicCategory.Item
        };

        return View(vm);
    }

    public async Task<IActionResult> EditMechanic(int id, string mechanic)
    {
        var result = await _managerService.UpdateMechanic(id, mechanic);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("MechanicsInfo");
    }

    public async Task<IActionResult> AddMechanic(string mechanic)
    {
        var result = await _managerService.AddMechanic(mechanic);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("MechanicsInfo");
    }

    public IActionResult AddMechanicPage() => View();

    public async Task<IActionResult> RemoveMechanic(int id)
    {
        var result = await _managerService.RemoveMechanic(id);
        if (result == null)
        {
            return View("Error");
        }

        return RedirectToAction("MechanicsInfo");
    }
}