namespace Catalog.Host.Models.Response;

public class GetItemResponse<T>
{
    public T Item { get; set; } = default(T) !;
}