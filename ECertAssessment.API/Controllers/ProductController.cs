using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECertAssessment.API.Models;
using ECertAssessment.Application.Category.Commands;
using ECertAssessment.Application.Category.Queries;
using ECertAssessment.Application.Product.Commands;
using ECertAssessment.Application.Product.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECertAssessment.API.Models.ApiResponse;

namespace ECertAssessment.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ApiController
    {

        [HttpPost]
        public async Task<ApiResponse> Create(CreateProductCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var product = await Mediator.Send(command);
                    apiResponse.ResponseMessage = product;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }

        [HttpPut]
        public async Task<ApiResponse> Update(UpdateProductCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var product = await Mediator.Send(command);
                    apiResponse.ResponseMessage = product;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }
        [HttpGet]
        public async Task<GetProductsResponse> GetAll(int start)
        {
            var apiResponse = new GetProductsResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var products = await Mediator.Send(new GetAllProductsQuery { Start = start, Length = 10});
                var productCount = await Mediator.Send(new GetAllProductCountQuery());
                apiResponse.ResponseType = 1;
                apiResponse.ResponseMessage = "Success";
                apiResponse.ResponseObject = products;
                apiResponse.NumberOfProducts = productCount;
                return apiResponse;
            }
            catch (Exception ex)
            {

                return apiResponse;
            }

        }

        [HttpGet("{id}")]
        public async Task<GetProductByIdResponse> Get(short id)
        {
            var apiResponse = new GetProductByIdResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var product = await Mediator.Send(new GetProductByIdQuery { Id = id });
                apiResponse.ResponseType = 1;
                apiResponse.ResponseMessage = "Success";
                apiResponse.ResponseObject = product;
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }


    }
}
