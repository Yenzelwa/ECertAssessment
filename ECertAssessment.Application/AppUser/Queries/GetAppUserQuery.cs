using ECertAssessment.Application.AppUser.Dto;
using MediatR;


namespace ECertAssessment.Application.AppUser.Queries
{
    public class GetAppUserQuery: IRequest<AppUserDto>
    {
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}
