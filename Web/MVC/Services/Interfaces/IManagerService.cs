namespace MVC.Services.Interfaces;

using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.ViewModels;

public interface IManagerService
{
    Task<ItemsListResponse<CatalogItem>> GetCatalogItems();
    Task<GetItemResponse<CatalogItem>> GetCatalogItem(int id);
    Task<AddItemResponse<int?>> AddItem(string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId);
    Task<RemoveItemResponse<int?>> RemoveItem(int id);
    Task<UpdateItemResponse<int?>> UpdateItem(int id, string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId);
    Task<ItemsListResponse<CatalogCategory>> GetCategories();
    Task<GetItemResponse<CatalogCategory>> GetCategory(int id);
    Task<GetItemResponse<int?>> AddCategory(string name);
    Task<RemoveItemResponse<int?>> RemoveCategory(int id);
    Task<UpdateItemResponse<int?>> UpdateCategory(int id, string name);
    Task<ItemsListResponse<CatalogMechanic>> GetMechanics();
    Task<GetItemResponse<CatalogMechanic>> GetMechanic(int id);
    Task<GetItemResponse<int?>> AddMechanic(string name);
    Task<RemoveItemResponse<int?>> RemoveMechanic(int id);
    Task<UpdateItemResponse<int?>> UpdateMechanic(int id, string name);
    Task<IEnumerable<SelectListItem>> GeеSelectedListCategories();
    Task<IEnumerable<SelectListItem>> GetSelectedListMechanics();
}