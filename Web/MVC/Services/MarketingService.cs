using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class MarketingService : IMarketingService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;

    public MarketingService(IHttpClientService httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<ItemsListResponse<MarketingItem>> GetReviews(int productId)
    {
        var result = await _httpClient.SendAsync<ItemsListResponse<MarketingItem>, GetMarketingItemRequest>($"{_settings.Value.MarketingUrl}/GetReviews",
        HttpMethod.Post,
        new GetMarketingItemRequest()
        {
            ProductId = productId 
        });

        return result;
    }

    public async Task<AddReviewResponse<int?>> AddReview(int productId, ApplicationUser user, string comment, int rating)
    {
        var result = await _httpClient.SendAsync<AddReviewResponse<int?>, AddReviewRequest>($"{_settings.Value.MarketingUrl}/AddReview",
        HttpMethod.Post,
        new AddReviewRequest
        {
            ProductId = productId,
            UserId = user.Id,
            Username = user.Name,
            Comment = comment,
            Rating = rating
        });

        return result;
    }

    public async Task<RemoveReviewResponse<int?>> RemoveReview(string userId)
    {
        var result = await _httpClient.SendAsync<RemoveReviewResponse<int?>, RemoveReviewRequest>($"{_settings.Value.MarketingUrl}/RemoveReview",
        HttpMethod.Post,
        new RemoveReviewRequest
        {
            UserId = userId
        });

        return result;
    }
}