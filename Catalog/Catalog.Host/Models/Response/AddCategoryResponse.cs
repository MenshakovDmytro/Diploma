namespace Catalog.Host.Models.Response;

public class AddCategoryResponse<T>
{
    public T Id { get; set; } = default(T) !;
}