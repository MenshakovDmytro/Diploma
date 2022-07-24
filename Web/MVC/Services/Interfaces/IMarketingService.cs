namespace MVC.Services.Interfaces;

using MVC.Models.Response;
using MVC.Models.Responses;
using MVC.ViewModels;

public interface IMarketingService
{
    Task<ItemsListResponse<MarketingItem>> GetReviews(int productId);
    Task<AddItemResponse<int?>> AddReview(int productId, ApplicationUser user, string comment, int rating);
    Task<RemoveReviewResponse<int?>> RemoveReview(string userId);
}