namespace Basket.Host.Controllers;

using Microsoft.AspNetCore.Authorization;
using Infrastructure.Identity;
using Basket.Host.Models.Dtos;
using Basket.Host.Models.Requests;
using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]

public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerBasketDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasket(GetBasketRequest getBasketRequest)
    {
        var result = await _basketService.GetBasket(getBasketRequest.Id);
        _logger.LogInformation($"GetBasket in controller returned {result}");
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddToBasket(AddItemRequest addItemRequest)
    {
        var result = await _basketService.AddItemToBasket(addItemRequest.Id, addItemRequest.BasketItem);
        _logger.LogInformation($"Result of AddToBasket in controller is {result.Result}");
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveFromBasketResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RemoveFromBasket(RemoveFromBasketRequest removeFromBasketRequest)
    {
        var result = await _basketService.RemoveItemFromBasket(removeFromBasketRequest.Id, removeFromBasketRequest.ItemId);
        _logger.LogInformation($"Result of Remove from basket in controller is {result.Result}");
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteBasketResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasket(DeleteBasketRequest deleteBasketRequest)
    {
        var result = await _basketService.DeleteAsync(deleteBasketRequest.Id);
        _logger.LogInformation($"Result of DeleteBasket in controller is {result.Result}");
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateQuantityResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateQuantity(UpdateQuantityRequest updateQuantityRequest)
    {
        var result = await _basketService.UpdateQuantity(updateQuantityRequest.Id, updateQuantityRequest.Quantities);
        _logger.LogInformation($"Result of UpdateQuantity in controller is {result.Result}");
        return Ok(result);
    }
}