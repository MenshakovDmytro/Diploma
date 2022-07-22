using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogCategoryService : BaseDataService<ApplicationDbContext>, ICatalogCategoryService
{
    private readonly ICatalogCategoryRepository _catalogCategoryRepository;
    private readonly IMapper _mapper;

    public CatalogCategoryService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogCategoryRepository catalogCategoryRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogCategoryRepository = catalogCategoryRepository;
        _mapper = mapper;
    }

    public async Task<AddCategoryResponse<int?>> AddAsync(string name)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCategoryRepository.AddAsync(name);
            return new AddCategoryResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<RemoveCategoryResponse<int?>> RemoveAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCategoryRepository.RemoveAsync(id);
            return new RemoveCategoryResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<UpdateCategoryResponse<int?>> UpdateAsync(int id, string name)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCategoryRepository.UpdateAsync(id, name);
            return new UpdateCategoryResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<ItemsListResponse<CatalogCategoryDto>> GetCategoriesAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCategoryRepository.GetCategoriesAsync();
            return new ItemsListResponse<CatalogCategoryDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCategoryDto>(s)).ToList(),
            };
        });
    }
}