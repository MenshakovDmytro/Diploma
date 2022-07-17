namespace Catalog.Host.Models.Response;

public class RemoveCategoryResponse<T>
{
    public T Id { get; set; } = default(T) !;
}