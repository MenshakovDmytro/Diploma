using MVC.ViewModels;

namespace MVC.Models.Requests
{
    public class AddBasketItemRequest
    {
        public string Id { get; set; }
        public BasketItem BasketItem { get; set; }
    }
}