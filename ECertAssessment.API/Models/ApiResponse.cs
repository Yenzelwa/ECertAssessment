
using ECertAssessment.Application.AppUser.Dto;
using ECertAssessment.Application.Category.Dto;
using ECertAssessment.Application.File.Dto;
using ECertAssessment.Application.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.API.Models
{
    public class ApiResponse
    {
        public int ResponseType { get; set; }

        public string ResponseMessage { get; set; }


        public class GetProductsResponse : ApiResponse
        {
            public List<ProductDto> ResponseObject { get; set; }
            public int NumberOfProducts { get; set; }


        }
        public class GetProductByIdResponse : ApiResponse
        {
            public ProductDto ResponseObject { get; set; }


        }
        public class GetCategoriesResponse : ApiResponse
        {
            public List<CategoryDto> ResponseObject { get; set; }


        }
        public class GetCategoryByIdResponse : ApiResponse
        {
            public CategoryDto ResponseObject { get; set; }


        }
        public class GetFileResponse : ApiResponse
        {
            public List<FileDto> ResponseObject { get; set; }


        }
        public class GetFileByIdResponse : ApiResponse
        {
            public FileDto ResponseObject { get; set; }


        }
        public class LoginUserResponse : ApiResponse
        {
            public UserLoginModel ResponseObject { get; set; }


        }
    }
}
