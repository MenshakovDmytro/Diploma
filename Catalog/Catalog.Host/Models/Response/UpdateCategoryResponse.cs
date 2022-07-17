namespace Catalog.Host.Models.Response;

public class UpdateCategoryResponse<T>
{
    public T Id { get; set; } = default(T) !;
}