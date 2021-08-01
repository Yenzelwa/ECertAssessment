using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class ProductModel
    {


        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short CategoryId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
