using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;

    public CatalogService(IHttpClientService httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<Catalog> GetCatalogItems(int page, int take, int? category, int? mechanic, int sort)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (category.HasValue)
        {
            filters.Add(CatalogTypeFilter.Category, category.Value);
        }
        
        if (mechanic.HasValue)
        {
            filters.Add(CatalogTypeFilter.Mechanic, mechanic.Value);
        }
        
        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/Items",
           HttpMethod.Post, 
           new PaginatedItemsRequest<CatalogTypeFilter>()
           {
                PageIndex = page,
                PageSize = take,
                Filters = filters,
                Sort = sort
           });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetCategories()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogCategory>, object?>(
            $"{_settings.Value.CatalogUrl}/GetCategories",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>();
        list.Add(new SelectListItem() { Text = "All" });
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

    public async Task<IEnumerable<SelectListItem>> GetMechanics()
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<CatalogMechanic>, object?>(
            $"{_settings.Value.CatalogUrl}/GetMechanics",
            HttpMethod.Post,
            null
            );

        var list = new List<SelectListItem>();
        list.Add(new SelectListItem() { Text = "All" });
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

    public async Task<GetItemResponse<CatalogItem>> GetItem(int id)
    {
        var result = await _httpClient.SendAsync<GetItemResponse<CatalogItem>, GetItemRequest<int>?>($"{_settings.Value.CatalogUrl}/GetItem",
            HttpMethod.Post,
            new GetItemRequest<int>
            {
                Id = id
            });

        return result;
    }

    public IEnumerable<SelectListItem> GetSortTypes()
    {
        var list = new List<SelectListItem>();
        list.Add(new SelectListItem() { Text = "All" });
        foreach (int item in Enum.GetValues(typeof(SortType)))
        {
            list.Add(new SelectListItem()
            {
                Value = item.ToString(),
                Text = Enum.GetName(typeof(SortType), item)
            });
        }

        return list;
    }
}