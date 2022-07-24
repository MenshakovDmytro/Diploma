namespace MVC.Models.Responses;

public class RemoveItemResponse<T>
{
    public T Id { get; set; } = default(T) !;
}