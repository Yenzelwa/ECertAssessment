using ECertAssessment.Application.Category.Commands;
using FluentValidation;

namespace ECertAssessment.Application.Category.Validators
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(t => t.CategoryCode).NotEmpty();
            RuleFor(t => t.Name).NotNull();
        }
    }
}
