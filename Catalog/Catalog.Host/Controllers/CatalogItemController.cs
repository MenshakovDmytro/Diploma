namespace Catalog.Host.Controllers;

using Microsoft.AspNetCore.Authorization;
using Infrastructure.Identity;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Models.Dtos;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(ICatalogItemService catalogItemService)
    {
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCatalogItems()
    {
        var result = await _catalogItemService.GetItemsAsync();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCatalogItem(GetItemRequest request)
    {
        var result = await _catalogItemService.GetItemAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.AddAsync(request.Name, request.Description, request.Price, request.CatalogCategoryId, request.CatalogMechanicId, request.PictureFileName);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Remove(RemoveRequest request)
    {
        var result = await _catalogItemService.RemoveAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateProductRequest request)
    {
        var result = await _catalogItemService.UpdateAsync(request.Id, request.Name, request.Description, request.Price, request.CatalogCategoryId, request.CatalogMechanicId, request.PictureFileName);
        return Ok(result);
    }
}