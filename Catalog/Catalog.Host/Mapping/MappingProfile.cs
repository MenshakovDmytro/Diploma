namespace Catalog.Host.Mapping;

using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogCategory, CatalogCategoryDto>();
        CreateMap<CatalogMechanic, CatalogMechanicDto>();
    }
}