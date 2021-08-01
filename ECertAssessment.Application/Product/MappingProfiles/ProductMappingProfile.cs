using AutoMapper;
using ECertAssessment.Application.Product.Commands;
using ECertAssessment.Application.Product.Dto;

namespace ECertAssessment.Application.Product.MappingProfiles
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductCommand, ECertAssessment.Domain.Entities.Product>();

            CreateMap<UpdateProductCommand, ECertAssessment.Domain.Entities.Product>();
            CreateMap<ECertAssessment.Domain.Entities.Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                 .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByNavigation.Email));
        }
    }
}
