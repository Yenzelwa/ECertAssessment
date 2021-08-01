using ECertAssessment.Application.AppUser.Commands;
using FluentValidation;

namespace ECertAssessment.Application.AppUser.Validators
{
    public class CreateAppUserCommandValidator: AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserCommandValidator()
        {
            RuleFor(t => t.Email).NotEmpty();
            RuleFor(t => t.PasswordHash).NotNull();
        }
    }
}
