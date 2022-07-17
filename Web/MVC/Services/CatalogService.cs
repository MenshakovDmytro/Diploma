using MVC.Dtos;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
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
        
        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
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
            $"{_settings.Value.CatalogUrl}/getCategories",
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
            $"{_settings.Value.CatalogUrl}/getMechanics",
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

    public async Task<CatalogItem> GetItem(int id)
    {
        var result = await _httpClient.SendAsync<CatalogItem, object?>(
            $"{_settings.Value.CatalogUrl}/GetItem",
            HttpMethod.Post,
            new GetItemRequest
            {
                Id = id
            });

        return result;
    }

    public IEnumerable<SelectListItem> GetSortTypes()
    {
        var values = Enum.GetNames(typeof(SortType));
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