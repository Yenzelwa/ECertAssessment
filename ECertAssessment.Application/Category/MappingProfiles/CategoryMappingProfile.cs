using AutoMapper;
using ECertAssessment.Application.Category.Commands;
using ECertAssessment.Application.Category.Dto;


namespace ECertAssessment.Application.Category.MappingProfiles
{
    public class CategoryMappingProfile: Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryCommand, ECertAssessment.Domain.Entities.Category>();
            CreateMap<UpdateCategoryCommand, ECertAssessment.Domain.Entities.Category>();
            CreateMap<ECertAssessment.Domain.Entities.Category, CategoryDto>()
                 .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByNavigation.Email));
        }
    }
}
