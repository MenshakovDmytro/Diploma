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
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<MarketingItem, MarketingItemDto>(s)).ToList()
            };
        });
    }
}