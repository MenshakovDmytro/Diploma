using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogMechanicService
{
    Task<AddMechanicResponse<int?>> AddAsync(string name);
    Task<RemoveMechanicResponse<int?>> RemoveAsync(int id);
    Task<UpdateMechanicResponse<int?>> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogMechanicDto>> GetMechanicsAsync();
    Task<GetItemResponse<CatalogMechanicDto>> GetMechanicAsync(int id);
}