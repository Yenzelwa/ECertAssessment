using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Application.Product.Commands;

namespace ECertAssessment.Application.Product.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Products.Update(_mapper.Map<ECertAssessment.Domain.Entities.Product>(request));
            return result;
        }
    }
}
