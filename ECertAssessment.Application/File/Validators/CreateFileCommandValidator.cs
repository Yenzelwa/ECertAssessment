using ECertAssessment.Application.File.Commands;
using FluentValidation;

namespace ECertAssessment.Application.File.Validators
{
    public class CreateFileCommandValidator: AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            RuleFor(t => t.FileName).NotEmpty();
            RuleFor(t => t.File1).NotNull();
        }
    }
}
