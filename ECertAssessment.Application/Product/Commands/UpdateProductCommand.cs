using MediatR;
using System;
namespace ECertAssessment.Application.Product.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {

        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

    }
}
