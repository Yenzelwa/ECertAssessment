using MediatR;
using System;
namespace ECertAssessment.Application.Product.Commands
{
    public class CreateProductCommand : IRequest<string>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CreatedBy { get; set; }


    }
}
