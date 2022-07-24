namespace Marketing.Host.Models.Requests;

public class AddReviewRequest
{
    public int ProductId { get; set; }
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}