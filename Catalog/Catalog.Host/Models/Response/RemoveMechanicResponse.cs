namespace Catalog.Host.Models.Response;

public class RemoveMechanicResponse<T>
{
    public T Id { get; set; } = default(T) !;
}