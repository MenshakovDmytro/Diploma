using Marketing.Host.Data;
using Marketing.Host.Data.Entities;
using Marketing.Host.Models.Dtos;
using Marketing.Host.Models.Responses;
using Marketing.Host.Repositories.Interfaces;
using Marketing.Host.Services.Interfaces;

namespace Marketing.Host.Services;

public class MarketingItemService : BaseDataService<ApplicationDbContext>, IMarketingItemService
{
    private readonly IMarketingItemRepository _marketingItemRepository;
    private readonly IMapper _mapper;

    public MarketingItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMarketingItemRepository marketingItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _marketingItemRepository = marketingItemRepository;
        _mapper = mapper;
    }

    public async Task<AddReviewResponse<int?>> AddReview(int productId, string userId, string username, string comment, int rating)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var productReviews = await _marketingItemRepository.GetItemsAsync(productId);
            var user = productReviews.Data.FirstOrDefault(f => f.UserId.Equals(userId));
            if (user is not null)
            {
                return new AddReviewResponse<int?>();
            }

            var result = await _marketingItemRepository.AddAsync(productId, userId, username, comment, rating);
            return new AddReviewResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<ItemsListResponse<MarketingItemDto>> GetReviews(int productId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _marketingItemRepository.GetItemsAsync(productId);
            return new ItemsListResponse<MarketingItemDto>()
            {
                Count = result.Count,
                Data = result.Data.Select(s => _mapper.Map<MarketingItemDto>(s)).ToList()
            };
        });
    }

    public async Task<RemoveReviewResponse<int?>> RemoveReview(string userId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _marketingItemRepository.RemoveByUserId(userId);
            return new RemoveReviewResponse<int?>()
            {
               Id= result
            };
        });
    }
}