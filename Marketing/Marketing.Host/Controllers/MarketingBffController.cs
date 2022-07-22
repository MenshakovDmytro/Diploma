using Marketing.Host.Models.Dtos;
using Marketing.Host.Models.Requests;
using Marketing.Host.Models.Responses;
using Marketing.Host.Services.Interfaces;

namespace Marketing.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class MarketingBffController : ControllerBase
{
    private readonly IMarketingItemService _marketingItemService;

    public MarketingBffController(IMarketingItemService marketingItemService)
    {
        _marketingItemService = marketingItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddReviewResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddReview(AddReviewRequest request)
    {
        var result = await _marketingItemService.AddReview(request.ProductId, request.UserId, request.Username, request.Comment, request.Rating);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<MarketingItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetReviews(GetReviewsRequest request)
    {
        var result = await _marketingItemService.GetReviews(request.ProductId);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveReviewResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RemoveReview(RemoveReviewRequest request)
    {
        var result = await _marketingItemService.RemoveReview(request.UserId);
        return Ok(result);
    }
}