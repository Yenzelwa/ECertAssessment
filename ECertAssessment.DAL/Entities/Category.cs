using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.DAL.Entities
{
    public partial class Category
    {
        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }
    }
}
