using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.DAL.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
