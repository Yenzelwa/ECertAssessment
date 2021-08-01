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
    public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, List<FileDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFilesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<FileDto>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Files.GetAll();
            return _mapper.Map<List<FileDto>>(result);
        }
    }
}
