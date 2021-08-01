using MediatR;
using System;
namespace ECertAssessment.Application.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<string>
    {

        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }

    }
}
