namespace Marketing.Host.Mapping;

using Marketing.Host.Data.Entities;
using Marketing.Host.Models.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MarketingItem, MarketingItemDto>();
    }
}