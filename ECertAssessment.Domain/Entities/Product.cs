using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.Domain.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
        public virtual AspNetUser CreatedByNavigation { get; set; }
    }
}
