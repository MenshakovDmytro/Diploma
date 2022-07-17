using Basket.Host.Data;
using Basket.Host.Models.Dtos;

namespace Basket.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BasketItem, BasketItemDto>();
        CreateMap<CustomerBasket, CustomerBasketDto>();
    }
}