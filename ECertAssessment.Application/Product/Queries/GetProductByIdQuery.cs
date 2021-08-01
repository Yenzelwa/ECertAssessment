using ECertAssessment.Application.Product.Dto;
using MediatR;

namespace ECertAssessment.Application.Product.Queries
{
    public class GetProductByIdQuery: IRequest<ProductDto>
    {
        public short Id{ get; set; }
    }
}
