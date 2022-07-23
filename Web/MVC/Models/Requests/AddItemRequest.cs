namespace MVC.Models.Requests;

public class AddItemRequest<T>
{
    public T Name { get; set; } = default(T)!;
}