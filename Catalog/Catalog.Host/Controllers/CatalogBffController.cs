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
    private readonly ICatalogCategoryService _catalogCategoryService;
    private readonly ICatalogMechanicService _catalogMechanicService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogCategoryService catalogCategoryService,
        ICatalogMechanicService catalogMechanicService)
    {
        _logger = logger;
        _catalogService = catalogService;
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