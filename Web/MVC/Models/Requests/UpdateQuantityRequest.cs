namespace MVC.Models.Requests
{
    public class UpdateQuantityRequest
    {
        public string Id { get; set; }
        public Dictionary<int, int> Quantities { get; set; }
    }
}