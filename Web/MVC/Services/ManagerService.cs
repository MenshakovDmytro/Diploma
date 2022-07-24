namespace MVC.Services;

using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

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

    public async Task<AddItemResponse<int?>> AddItem(string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId)
    {
        var result = await _httpClient.SendAsync<AddItemResponse<int?>, AddCatalogItemRequest>(
            $"{_settings.Value.CatalogItemUrl}/Add",
            HttpMethod.Post,
            new AddCatalogItemRequest()
            {
                Name = name,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                CatalogCategoryId = categoryId,
                CatalogMechanicId = mechanicId,
            });

        return result;
    }

    public async Task<RemoveItemResponse<int?>> RemoveItem(int id)
    {
        var result = await _httpClient.SendAsync<RemoveItemResponse<int?>, RemoveItemRequest<int>>(
            $"{_settings.Value.CatalogItemUrl}/Remove",
            HttpMethod.Post,
            new RemoveItemRequest<int>()
            {
                Id = id
            });

        return result;
    }

    public async Task<UpdateItemResponse<int?>> UpdateItem(int id, string name, string description, decimal price, string pictureFileName, int categoryId, int mechanicId)
    {
        var result = await _httpClient.SendAsync<UpdateItemResponse<int?>, UpdateCatalogItemRequest>(
            $"{_settings.Value.CatalogItemUrl}/Update",
            HttpMethod.Post,
            new UpdateCatalogItemRequest()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                CatalogCategoryId = categoryId,
                CatalogMechanicId = mechanicId,
            });

        return result;
    }

    public async Task<ItemsListResponse<CatalogCategory>> GetCategories()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogCategory>, object?>(
            $"{_settings.Value.CatalogCategoryUrl}/GetCategories",
            HttpMethod.Post,
            null);

        return result;
    }

    public async Task<GetItemResponse<CatalogCategory>> GetCategory(int id)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<CatalogCategory>, GetItemRequest<int>>(
            $"{_settings.Value.CatalogCategoryUrl}/GetCategory",
            HttpMethod.Post,
            new GetItemRequest<int>
            {
                Id = id
            });

        return result;
    }

    public async Task<GetItemResponse<int?>> AddCategory(string name)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<int?>, AddItemRequest<string>>(
            $"{_settings.Value.CatalogCategoryUrl}/Add",
            HttpMethod.Post,
            new AddItemRequest<string>()
            {
                Name = name
            });

        return result;
    }

    public async Task<RemoveItemResponse<int?>> RemoveCategory(int id)
    {
        var result = await _httpClient.SendAsync<RemoveItemResponse<int?>, RemoveItemRequest<int>>(
            $"{_settings.Value.CatalogCategoryUrl}/Remove",
            HttpMethod.Post,
            new RemoveItemRequest<int>()
            {
                Id = id
            });

        return result;
    }

    public async Task<UpdateItemResponse<int?>> UpdateCategory(int id, string name)
    {
        var result = await _httpClient.SendAsync<UpdateItemResponse<int?>, UpdateItemRequest<string>>(
            $"{_settings.Value.CatalogCategoryUrl}/Update",
            HttpMethod.Post,
            new UpdateItemRequest<string>()
            {
                Id = id,
                Name = name
            });

        return result;
    }

    public async Task<ItemsListResponse<CatalogMechanic>> GetMechanics()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogMechanic>, object?>(
            $"{_settings.Value.CatalogMechanicUrl}/GetMechanics",
            HttpMethod.Post,
            null);

        return result;
    }

    public async Task<GetItemResponse<CatalogMechanic>> GetMechanic(int id)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<CatalogMechanic>, GetItemRequest<int>>(
            $"{_settings.Value.CatalogMechanicUrl}/GetMechanic",
            HttpMethod.Post,
            new GetItemRequest<int>
            {
                Id = id
            });

        return result;
    }

    public async Task<GetItemResponse<int?>> AddMechanic(string name)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<int?>, AddItemRequest<string>>(
            $"{_settings.Value.CatalogMechanicUrl}/Add",
            HttpMethod.Post,
            new AddItemRequest<string>()
            {
                Name = name
            });

        return result;
    }

    public async Task<RemoveItemResponse<int?>> RemoveMechanic(int id)
    {
        var result = await _httpClient.SendAsync<RemoveItemResponse<int?>, RemoveItemRequest<int>>(
            $"{_settings.Value.CatalogMechanicUrl}/Remove",
            HttpMethod.Post,
            new RemoveItemRequest<int>()
            {
                Id = id
            });

        return result;
    }

    public async Task<UpdateItemResponse<int?>> UpdateMechanic(int id, string name)
    {
        var result = await _httpClient.SendAsync<UpdateItemResponse<int?>, UpdateItemRequest<string>>(
            $"{_settings.Value.CatalogMechanicUrl}/Update",
            HttpMethod.Post,
            new UpdateItemRequest<string>()
            {
                Id = id,
                Name = name
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GeеSelectedListCategories()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogCategory>, object?>(
            $"{_settings.Value.CatalogCategoryUrl}/GetCategories",
            HttpMethod.Post,
            null);

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

    public async Task<IEnumerable<SelectListItem>> GetSelectedListMechanics()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogMechanic>, object?>(
            $"{_settings.Value.CatalogMechanicUrl}/GetMechanics",
            HttpMethod.Post,
            null);

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