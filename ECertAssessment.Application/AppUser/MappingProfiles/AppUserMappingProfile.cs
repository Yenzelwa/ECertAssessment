using AutoMapper;
using ECertAssessment.Application.AppUser.Commands;
using ECertAssessment.Application.AppUser.Dto;

namespace ECertAssessment.Application.AppUser.MappingProfiles
{
    public class AppUserMappingProfile: Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<CreateAppUserCommand, ECertAssessment.Domain.Entities.AspNetUser>();
            CreateMap<ECertAssessment.Domain.Entities.AspNetUser, AppUserDto>();
        }
    }
}
