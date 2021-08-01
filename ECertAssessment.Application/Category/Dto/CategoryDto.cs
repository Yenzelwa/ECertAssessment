using System;

namespace ECertAssessment.Application.Category.Dto
{
    public class CategoryDto
    {
        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
