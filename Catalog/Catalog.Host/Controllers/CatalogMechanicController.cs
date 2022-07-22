using Microsoft.AspNetCore.Authorization;
using Infrastructure.Identity;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogmechanic")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogMechanicController : ControllerBase
{
    private readonly ILogger<CatalogMechanicController> _logger;
    private readonly ICatalogMechanicService _catalogMechanicService;

    public CatalogMechanicController(
        ILogger<CatalogMechanicController> logger,
        ICatalogMechanicService catalogMechanicService)
    {
        _logger = logger;
        _catalogMechanicService = catalogMechanicService;
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