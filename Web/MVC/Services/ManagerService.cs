using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class ManagerService : IManagerService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;

    public ManagerService(
        IHttpClientService httpClient,
        IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<ItemsListResponse<CatalogItem>> GetCatalogItems()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogItem>, object?>(
            $"{_settings.Value.CatalogItemUrl}/GetCatalogItems",
            HttpMethod.Post,
            null);

        return result;
    }

    public async Task<GetItemResponse<CatalogItem>> GetCatalogItem(int id)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<CatalogItem>, GetItemRequest<int>>(
            $"{_settings.Value.CatalogItemUrl}/GetCatalogItem",
            HttpMethod.Post,
            new GetItemRequest<int>
            {
                Id = id
            });

        return result;
    }

    public async Task<CatalogItem?> AddItem(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId)
    {
        var result = await _httpClient.SendAsync<CatalogItem?, AddCatalogItemRequest>(
            $"{_settings.Value.CatalogItemUrl}/Add",
            HttpMethod.Post,
            new AddCatalogItemRequest()
            {
                Name = name,
                Description = description,
                Price = price,
                CatalogCategoryId = catalogCategoryId,
                CatalogMechanicId = catalogMechanicId,
            });

        return result;
    }

    public async Task<CatalogItem?> RemoveItem(int id)
    {
        var result = await _httpClient.SendAsync<CatalogItem?, RemoveItemRequest<int>>(
            $"{_settings.Value.CatalogItemUrl}/Remove",
            HttpMethod.Post,
            new RemoveItemRequest<int>()
            {
                Id = id
            });

        return result;
    }

    public async Task<CatalogItem?> UpdateItem(int id, string name, string description, decimal price, int categoryId, int catalogMechanicId)
    {
        var result = await _httpClient.SendAsync<CatalogItem?, UpdateCatalogItemRequest>(
            $"{_settings.Value.CatalogItemUrl}/Update",
            HttpMethod.Post,
            new UpdateCatalogItemRequest()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                CatalogCategoryId = categoryId,
                CatalogMechanicId = catalogMechanicId,
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetCategoriesSelectedList()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogCategory>, object?>(
            $"{_settings.Value.CatalogCategoryUrl}/GetCategories",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>();
        foreach (var item in result.Data)
        {
            list.Add(new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Category
            });
        }

        return list;
    }

    public async Task<IEnumerable<SelectListItem>> GetMechanicsSelectedList()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogMechanic>, object?>(
            $"{_settings.Value.CatalogMechanicUrl}/GetMechanics",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>();
        foreach (var item in result.Data)
        {
            list.Add(new SelectListItem()
            {
                Value = item.Id.ToString(),
                Text = item.Mechanic
            });
        }

        return list;
    }
}