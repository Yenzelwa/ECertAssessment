using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECertAssessment.API.Models;
using ECertAssessment.Application.Category.Commands;
using ECertAssessment.Application.Category.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECertAssessment.API.Models.ApiResponse;

namespace ECertAssessment.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ApiController
    {

        [HttpPost]
        public async Task<ApiResponse> Create(CreateCategoryCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var category = await Mediator.Send(command);
                    apiResponse.ResponseMessage = category;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }

        [HttpPut]
        public async Task<ApiResponse> Update(UpdateCategoryCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var category = await Mediator.Send(command);
                    apiResponse.ResponseMessage = category;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception ex)
            {

                return apiResponse;
            }
        }
        [HttpGet]
        public async Task<GetCategoriesResponse> GetAll()
        {
            var apiResponse = new GetCategoriesResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var categories = await Mediator.Send(new GetAllCategoryQuery());
                apiResponse.ResponseType = 1;
                apiResponse.ResponseMessage = "Success";
                apiResponse.ResponseObject = categories;
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
             
        }

        [HttpGet("{id}")]
        public async Task<GetCategoryByIdResponse> Get(short id)
        {
            var apiResponse = new GetCategoryByIdResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var category = await Mediator.Send(new GetCategoryByIdQuery { Id = id});
                apiResponse.ResponseType = 1;
                apiResponse.ResponseMessage = "Success";
                apiResponse.ResponseObject = category;
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }

       
    }
}
