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
public class CatalogMechanicController : ControllerBase
{
    private readonly ICatalogMechanicService _catalogMechanicService;

    public CatalogMechanicController(ICatalogMechanicService catalogMechanicService)
    {
        _catalogMechanicService = catalogMechanicService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<CatalogMechanicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMechanics()
    {
        var result = await _catalogMechanicService.GetMechanicsAsync();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemResponse<CatalogMechanicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMechanic(GetItemRequest request)
    {
        var result = await _catalogMechanicService.GetMechanicAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddMechanicResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateMechanicRequest request)
    {
        var result = await _catalogMechanicService.AddAsync(request.Name);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveMechanicResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Remove(RemoveMechanicRequest request)
    {
        var result = await _catalogMechanicService.RemoveAsync(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateMechanicResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateMechanicRequest request)
    {
        var result = await _catalogMechanicService.UpdateAsync(request.Id, request.Name);
        return Ok(result);
    }
}