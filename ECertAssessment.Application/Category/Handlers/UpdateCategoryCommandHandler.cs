using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.Category.Commands;

namespace ECertAssessment.Application.Category.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Categories.Update(_mapper.Map<ECertAssessment.Domain.Entities.Category>(request));
            return result;
        }
    }
}
