namespace MVC.Models.Requests;

public class UpdateItemRequest<T>
{
    public int Id { get; set; }
    public T Name { get; set; } = default(T) !;
}