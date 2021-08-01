using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.File.Commands;

namespace ECertAssessment.Application.File.Handlers
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Files.Add(_mapper.Map<ECertAssessment.Domain.Entities.File>(request));
            return result;
        }
    }
}
