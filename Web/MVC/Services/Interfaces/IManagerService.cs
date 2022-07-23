using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface IManagerService
{
    Task<ItemsListResponse<CatalogItem>> GetCatalogItems();
    Task<GetItemResponse<CatalogItem>> GetCatalogItem(int id);
    Task<CatalogItem?> AddItem(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId);
    Task<CatalogItem?> RemoveItem(int id);
    Task<CatalogItem?> UpdateItem(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId);
    Task<IEnumerable<SelectListItem>> GetCategoriesSelectedList();
    Task<IEnumerable<SelectListItem>> GetMechanicsSelectedList();
}