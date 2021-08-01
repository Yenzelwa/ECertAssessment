using ECertAssessment.Application.File.Dto;
using MediatR;


namespace ECertAssessment.Application.File.Queries
{
    public class GetFileByIdQuery: IRequest<FileDto>
    {
      public int Id { get; set; }
    }
}
