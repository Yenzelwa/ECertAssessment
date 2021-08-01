using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.AppUser.Commands;

namespace ECertAssessment.Application.AppUser.Handlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AppUsers.AddUser(_mapper.Map<ECertAssessment.Domain.Entities.AspNetUser>(request));
            return result;
        }
    }
}
