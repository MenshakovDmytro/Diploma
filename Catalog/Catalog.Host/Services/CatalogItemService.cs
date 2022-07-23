using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<AddItemResponse<int?>> AddAsync(string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.AddAsync(name, description, price, catalogCategoryId, catalogMechanicId);
            return new AddItemResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<RemoveItemResponse<int?>> RemoveAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.RemoveAsync(id);
            return new RemoveItemResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name, string description, decimal price, int catalogCategoryId, int catalogMechanicId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.UpdateAsync(id, name, description, price, catalogCategoryId, catalogMechanicId);
            return new UpdateCategoryResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<ItemsListResponse<CatalogItemDto>> GetItemsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetItemsAsync();
            return new ItemsListResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
            };
        });
    }

    public async Task<GetItemResponse<CatalogItemDto>> GetItemAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetItemAsync(id);
            return new GetItemResponse<CatalogItemDto>()
            {
                Item = _mapper.Map<CatalogItemDto>(result)
            };
        });
    }
}