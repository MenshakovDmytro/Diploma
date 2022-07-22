namespace Marketing.Host.Models.Responses;

public class RemoveReviewResponse<T>
{
    public T Id { get; set; } = default(T)!;
}