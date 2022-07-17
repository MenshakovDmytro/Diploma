using Microsoft.AspNetCore.Authorization;
using Infrastructure.Identity;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogcategory")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogCategoryController : ControllerBase
{
    private readonly ILogger<CatalogCategoryController> _logger;
    private readonly ICatalogCategoryService _catalogCategoryService;

    public CatalogCategoryController(
        ILogger<CatalogCategoryController> logger,
        ICatalogCategoryService catalogCategoryService)
    {
        _logger = logger;
        _catalogCategoryService = catalogCategoryService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCategoryRequest request)
    {
        var result = await _catalogCategoryService.AddAsync(request.Name);
        return Ok(new AddCategoryResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Remove(RemoveCategoryRequest request)
    {
        var result = await _catalogCategoryService.RemoveAsync(request.Id);
        return Ok(new RemoveCategoryResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateCategoryRequest request)
    {
        var result = await _catalogCategoryService.UpdateAsync(request.Id, request.Name);
        return Ok(new UpdateCategoryResponse<int?>() { Id = result });
    }
}