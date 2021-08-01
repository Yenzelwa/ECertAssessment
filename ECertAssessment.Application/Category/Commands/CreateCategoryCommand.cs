using MediatR;
using System;
namespace ECertAssessment.Application.Category.Commands
{
    public class CreateCategoryCommand : IRequest<string>
    {

        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }

    }
}
