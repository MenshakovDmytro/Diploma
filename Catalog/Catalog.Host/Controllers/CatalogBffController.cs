using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogCategoryService _catalogCategoryService;
    private readonly ICatalogMechanicService _catalogMechanicService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogCategoryService catalogCategoryService,
        ICatalogMechanicService catalogMechanicService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogCategoryService = catalogCategoryService;
        _catalogMechanicService = catalogMechanicService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters, request.Sort);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItem(GetItemRequest request)
    {
        var result = await _catalogItemService.GetItemAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogCategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _catalogCategoryService.GetCategoriesAsync();
        _logger.LogInformation($"GetCategories in controller returned {result.Count} items");
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogMechanicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMechanics()
    {
        var result = await _catalogMechanicService.GetMechanicsAsync();
        _logger.LogInformation($"GetMechanics in controller returned {result.Count} items");
        return Ok(result);
    }
}