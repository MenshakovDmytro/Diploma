namespace MVC.Models.Responses;

public class GetItemResponse<T>
{
    public T Item { get; set; } = default(T)!;
}