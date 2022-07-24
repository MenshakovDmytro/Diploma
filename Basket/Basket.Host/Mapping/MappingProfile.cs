namespace Basket.Host.Mapping;

using Basket.Host.Data;
using Basket.Host.Models.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BasketItem, BasketItemDto>();
        CreateMap<CustomerBasket, CustomerBasketDto>();
    }
}