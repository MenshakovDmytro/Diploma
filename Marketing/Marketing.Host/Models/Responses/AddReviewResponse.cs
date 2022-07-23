namespace Marketing.Host.Models.Responses;

public class AddReviewResponse<T>
{
    public T Id { get; set; } = default(T) !;
}