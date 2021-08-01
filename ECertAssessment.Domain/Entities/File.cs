using System;
using System.Collections.Generic;

#nullable disable

namespace ECertAssessment.Domain.Entities
{
    public partial class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string File1 { get; set; }
        public int CreateBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual AspNetUser CreateByNavigation { get; set; }
    }
}
