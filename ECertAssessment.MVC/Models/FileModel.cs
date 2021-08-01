using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string File1 { get; set; }
        public int CreateBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUser { get; set; }
    }
}
