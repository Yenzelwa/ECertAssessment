
using ECertAssessment.MVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static ECertAssessment.MVC.Models.ApiResponse;

namespace ECertAssessment.MVC.API.Service
{
    public class CategoryService
    {

        public async Task<GetAllCategoryResponse> GetAllCategories(string token)
        {
            IRestRequest request = new RestRequest("api/category", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetAllCategoryResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    return null;
                }
            }
            return response.Data;

        }
        public async Task<GetCategoryResponse> GetAllCategoryById(int id,string token)
        {
            IRestRequest request = new RestRequest($"api/category/{id}", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetCategoryResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<ApiResponse> AddCategory(CategoryModel Category ,string token)
        {
            IRestRequest request = new RestRequest("api/category", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(Category);
            var response = await RestECert.ExecuteAsync<ApiResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<ApiResponse> UpdateCategory(CategoryModel Category , string token)
        {
            IRestRequest request = new RestRequest("api/category", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(Category);
            var response = await RestECert.ExecuteAsync<ApiResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }

    }
}
