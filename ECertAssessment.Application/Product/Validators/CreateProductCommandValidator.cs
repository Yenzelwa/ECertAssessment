using ECertAssessment.Application.Product.Commands;
using FluentValidation;

namespace ECertAssessment.Application.Product.Validators
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(t => t.Name).NotNull();
        }
    }
}
