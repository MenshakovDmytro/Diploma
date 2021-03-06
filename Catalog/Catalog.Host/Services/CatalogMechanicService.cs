namespace Catalog.Host.Services;

using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

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

    public async Task<AddResponse<int?>> AddAsync(string name)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogMechanicRepository.AddAsync(name);
            return new AddResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<RemoveMechanicResponse<int?>> RemoveAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogMechanicRepository.RemoveAsync(id);
            return new RemoveMechanicResponse<int?>()
            {
                Id = result
            };
        });
    }

    public async Task<UpdateMechanicResponse<int?>> UpdateAsync(int id, string name)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogMechanicRepository.UpdateAsync(id, name);
            return new UpdateMechanicResponse<int?>()
            {
                Id = result
            };
        });
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

    public async Task<GetItemResponse<CatalogMechanicDto>> GetMechanicAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogMechanicRepository.GetMechanicAsync(id);
            return new GetItemResponse<CatalogMechanicDto>()
            {
                Item = _mapper.Map<CatalogMechanicDto>(result)
            };
        });
    }
}