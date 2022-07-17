using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogMechanicService : BaseDataService<ApplicationDbContext>, ICatalogMechanicService
{
    private readonly ICatalogMechanicRepository _catalogMechanicRepository;
    private readonly IMapper _mapper;

    public CatalogMechanicService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogMechanicRepository catalogMechanicRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogMechanicRepository = catalogMechanicRepository;
        _mapper = mapper;
    }

    public Task<int?> AddAsync(string name)
    {
        return ExecuteSafeAsync(() => _catalogMechanicRepository.AddAsync(name));
    }

    public Task<int?> RemoveAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogMechanicRepository.RemoveAsync(id));
    }

    public Task<int?> UpdateAsync(int id, string name)
    {
        return ExecuteSafeAsync(() => _catalogMechanicRepository.UpdateAsync(id, name));
    }

    public async Task<ItemsListResponse<CatalogMechanicDto>> GetMechanicsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogMechanicRepository.GetMechanicsAsync();
            return new ItemsListResponse<CatalogMechanicDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogMechanicDto>(s)).ToList(),
            };
        });
    }
}