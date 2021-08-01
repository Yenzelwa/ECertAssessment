using AutoMapper;
using ECertAssessment.Application.Category.Dto;
using ECertAssessment.Application.Category.Queries;
using ECertAssessment.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECertAssessment.Application.c.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Categories.GetAll();
            return _mapper.Map<List<CategoryDto>>(result);
        }
    }
}
