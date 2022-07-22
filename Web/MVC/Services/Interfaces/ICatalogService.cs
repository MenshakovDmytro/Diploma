using MVC.Models.Responses;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogItems(int page, int take, int? category, int? mechanic, int sort);
    Task<IEnumerable<SelectListItem>> GetCategories();
    Task<IEnumerable<SelectListItem>> GetMechanics();
    Task<GetItemResponse<CatalogItem>> GetItem(int id);
    IEnumerable<SelectListItem> GetSortTypes();
}