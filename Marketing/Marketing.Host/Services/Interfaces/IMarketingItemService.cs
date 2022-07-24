namespace Marketing.Host.Services.Interfaces;

using Marketing.Host.Models.Dtos;
using Marketing.Host.Models.Responses;

public interface IMarketingItemService
{
    Task<AddReviewResponse<int?>> AddReview(int productId, string userId, string username, string comment, int rating);
    Task<RemoveReviewResponse<int?>> RemoveReview(string userId);
    Task<ItemsListResponse<MarketingItemDto>> GetReviews(int productId);
}