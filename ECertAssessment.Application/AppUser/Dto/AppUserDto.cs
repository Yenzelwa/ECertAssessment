using System;

namespace ECertAssessment.Application.AppUser.Dto
{
    public class AppUserDto
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
