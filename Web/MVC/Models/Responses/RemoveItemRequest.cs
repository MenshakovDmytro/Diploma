namespace MVC.Models.Responses;

public class RemoveItemRequest<T>
{
    public T Id { get; set; } = default(T) !;
}