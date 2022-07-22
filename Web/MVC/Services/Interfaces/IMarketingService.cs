using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface IMarketingService
{
    Task<ItemsListResponse<MarketingItem>> GetReviews(int productId);
    Task<AddReviewResponse<int?>> AddReview(int productId, ApplicationUser user, string comment, int rating);
    Task<RemoveReviewResponse<int?>> RemoveReview(string userId);
}