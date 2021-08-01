using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.AppUser.Queries;
using ECertAssessment.Application.AppUser.Dto;

namespace ECertAssessment.Application.AppUser.Handlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, AppUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAppUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppUserDto> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AppUsers.LoginUser(request.Email , request.Password);
            return _mapper.Map<AppUserDto>(result);
        }
    }
}
