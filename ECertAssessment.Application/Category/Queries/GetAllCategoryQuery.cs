using ECertAssessment.Application.Category.Dto;
using MediatR;
using System.Collections.Generic;

namespace ECertAssessment.Application.Category.Queries
{
    public class GetAllCategoryQuery: IRequest<List<CategoryDto>>
    {
 
    }
}
