namespace MVC.Models.Requests
{
    public class UpdateQuantityRequest
    {
        public string Id { get; set; } = null!;
        public Dictionary<int, int> Quantities { get; set; } = new Dictionary<int, int>();
    }
}