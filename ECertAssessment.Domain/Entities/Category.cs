using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
