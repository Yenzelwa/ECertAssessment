using System;

namespace ECertAssessment.Application.File.Dto
{
    public class FileDto
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public string File1 { get; set; }
        public int CreateBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUser { get; set; }
    }
}
