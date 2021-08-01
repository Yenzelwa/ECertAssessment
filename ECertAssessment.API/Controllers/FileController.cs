using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECertAssessment.API.Common;
using ECertAssessment.API.Controllers;
using ECertAssessment.API.Models;
using ECertAssessment.API.Providers.Security;
using ECertAssessment.Application.AppUser.Commands;
using ECertAssessment.Application.AppUser.Queries;
using ECertAssessment.Application.File.Commands;
using ECertAssessment.Application.File.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECertAssessment.API.Models.ApiResponse;

namespace ECertAssessment.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ApiController
    {
        [HttpPost]
        public async Task<ApiResponse> AddFile(CreateFileCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var file = await Mediator.Send(command);
                    apiResponse.ResponseMessage = file;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }

        [HttpGet]
        public async Task<GetFileResponse> GetAll()
        {
            var apiResponse = new GetFileResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var file = await Mediator.Send(new GetAllFilesQuery());
                if (file != null)
                {
                    apiResponse.ResponseType = 1;
                    apiResponse.ResponseMessage = "Success";
                    apiResponse.ResponseObject = file;
                }
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
             
        }
        [HttpGet("{id}")]
        public async Task<GetFileByIdResponse> Get(int id)
        {
            var apiResponse = new GetFileByIdResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var file = await Mediator.Send(new GetFileByIdQuery { Id =  id});
                if (file != null)
                {
                    apiResponse.ResponseType = 1;
                    apiResponse.ResponseMessage = "Success";
                    apiResponse.ResponseObject = file;
                }
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }

        }

    }
}
