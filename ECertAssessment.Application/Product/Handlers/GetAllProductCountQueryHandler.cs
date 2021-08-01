using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.Product.Dto;
using ECertAssessment.Application.Product.Queries;

namespace ECertAssessment.Application.Product.Handlers
{
    public class GetAllProductCountQueryHandler : IRequestHandler<GetAllProductCountQuery,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductCountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(GetAllProductCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Products.GetAllCount();
            return result;
        }
    }
}
