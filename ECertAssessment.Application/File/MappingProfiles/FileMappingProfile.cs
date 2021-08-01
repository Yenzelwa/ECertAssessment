using AutoMapper;
using ECertAssessment.Application.File.Commands;
using ECertAssessment.Application.File.Dto;

namespace ECertAssessment.Application.File.MappingProfiles
{
    public class FileMappingProfile: Profile
    {
        public FileMappingProfile()
        {
            CreateMap<CreateFileCommand, ECertAssessment.Domain.Entities.File>();
            CreateMap<ECertAssessment.Domain.Entities.File, FileDto>()
                 .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreateByNavigation.Email));
        }
    }
}
