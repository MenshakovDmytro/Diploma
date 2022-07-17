namespace Catalog.Host.Models.Response;

public class AddMechanicResponse<T>
{
    public T Id { get; set; } = default(T) !;
}