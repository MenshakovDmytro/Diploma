using Microsoft.AspNetCore.Authorization;
using Infrastructure.Identity;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogCategoryController : ControllerBase
{
    private readonly ICatalogCategoryService _catalogCategoryService;

    public CatalogCategoryController(ICatalogCategoryService catalogCategoryService)
    {
        _catalogCategoryService = catalogCategoryService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogCategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _catalogCategoryService.GetCategoriesAsync();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogCategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategory(GetItemRequest request)
    {
        var result = await _catalogCategoryService.GetCategoryAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCategoryRequest request)
    {
        var result = await _catalogCategoryService.AddAsync(request.Name);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Remove(RemoveCategoryRequest request)
    {
        var result = await _catalogCategoryService.RemoveAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateCategoryResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateCategoryRequest request)
    {
        var result = await _catalogCategoryService.UpdateAsync(request.Id, request.Name);
        return Ok(result);
    }
}