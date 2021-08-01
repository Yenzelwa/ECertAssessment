using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.File.Queries;
using ECertAssessment.Application.File.Dto;

namespace ECertAssessment.Application.File.Handlers
{
    public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFileByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FileDto> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Files.Get(request.Id);
            return _mapper.Map<FileDto>(result);
        }
    }
}
