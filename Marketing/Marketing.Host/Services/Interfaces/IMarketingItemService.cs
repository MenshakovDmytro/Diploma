using Marketing.Host.Models.Dtos;
using Marketing.Host.Models.Responses;

namespace Marketing.Host.Services.Interfaces;

public interface IMarketingItemService
{
    Task<AddReviewResponse<int?>> AddReview(int productId, string userId, string username, string comment, int rating);
    Task<ItemsListResponse<MarketingItemDto>> GetReviews(int productId);
}