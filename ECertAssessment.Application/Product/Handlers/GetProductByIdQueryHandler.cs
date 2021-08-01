using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Product.Dto;
using ECertAssessment.Application.Product.Queries;
using ECertAssessment.Application.Interfaces;

namespace ECertAssessment.Application.Product.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Products.Get(request.Id);
            return _mapper.Map<ProductDto>(result);
        }
    }
}
