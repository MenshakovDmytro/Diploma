using Marketing.Host.Data.Entities;
using Marketing.Host.Models.Dtos;

namespace Marketing.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MarketingItem, MarketingItemDto>();
    }
}