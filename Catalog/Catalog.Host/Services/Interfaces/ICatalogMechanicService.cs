using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogMechanicService
{
    Task<int?> AddAsync(string name);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogMechanicDto>> GetMechanicsAsync();
}