namespace Catalog.Host.Services.Interfaces;

using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

public interface ICatalogMechanicService
{
    Task<AddResponse<int?>> AddAsync(string name);
    Task<RemoveMechanicResponse<int?>> RemoveAsync(int id);
    Task<UpdateMechanicResponse<int?>> UpdateAsync(int id, string name);
    Task<ItemsListResponse<CatalogMechanicDto>> GetMechanicsAsync();
    Task<GetItemResponse<CatalogMechanicDto>> GetMechanicAsync(int id);
}