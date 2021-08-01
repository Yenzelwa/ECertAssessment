using ECertAssessment.Application.Category.Dto;
using MediatR;

namespace ECertAssessment.Application.Category.Queries
{
    public class GetCategoryByIdQuery: IRequest<CategoryDto>
    {
        public short Id { get; set; }
    }
}
