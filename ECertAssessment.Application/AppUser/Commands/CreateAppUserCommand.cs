using MediatR;
using System;
namespace ECertAssessment.Application.AppUser.Commands
{
    public class CreateAppUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
