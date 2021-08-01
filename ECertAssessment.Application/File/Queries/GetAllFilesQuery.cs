using ECertAssessment.Application.File.Dto;
using MediatR;
using System.Collections.Generic;

namespace ECertAssessment.Application.File.Queries
{
    public class GetAllFilesQuery: IRequest<List<FileDto>>
    {

    }
}
