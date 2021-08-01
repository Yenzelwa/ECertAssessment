using ECertAssessment.Application.Product.Dto;
using MediatR;
using System.Collections.Generic;

namespace ECertAssessment.Application.Product.Queries
{
    public class GetAllProductsQuery: IRequest<List<ProductDto>>
    {
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
