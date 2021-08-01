using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECertAssessment.MVC.Models
{
    public class ApiResponse
    {
        public int ResponseType { get; set; }

        public string ResponseMessage { get; set; }

        public class GetAllProductResponse : ApiResponse
        {
            public List<ProductModel> ResponseObject { get; set; }
            public int NumberOfProducts { get; set; }


        }
        public class GetProductResponse : ApiResponse
        {
            public ProductModel ResponseObject { get; set; }


        }

        public class GetAllCategoryResponse : ApiResponse
        {
            public List<CategoryModel> ResponseObject { get; set; }


        }
        public class GetCategoryResponse : ApiResponse
        {
            public CategoryModel ResponseObject { get; set; }


        }
        public class UserLoginResponse : ApiResponse
        {
            public UserLoginModel ResponseObject { get; set; }


        }
        public class GetAllFileResponse : ApiResponse
        {
            public List<FileModel> ResponseObject { get; set; }


        }
        public class GetFileByIdResponse : ApiResponse
        {
            public FileModel ResponseObject { get; set; }


        }

    }
}
