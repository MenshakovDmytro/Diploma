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

    public Task<int?> AddAsync(string name)
    {
        return ExecuteSafeAsync(() => _catalogCategoryRepository.AddAsync(name));
    }

    public Task<int?> RemoveAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogCategoryRepository.RemoveAsync(id));
    }

    public Task<int?> UpdateAsync(int id, string name)
    {
        return ExecuteSafeAsync(() => _catalogCategoryRepository.UpdateAsync(id, name));
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