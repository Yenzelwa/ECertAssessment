using MediatR;
using System;
namespace ECertAssessment.Application.File.Commands
{
    public class CreateFileCommand : IRequest<string>
    {
        public string FileName { get; set; }
        public string File1 { get; set; }
        public int CreateBy { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
