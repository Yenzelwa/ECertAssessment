
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
    public class ProductService
    {
        public async Task<GetAllProductResponse> GetAllProducts(string token , int start)
        {
            IRestRequest request = new RestRequest($"api/product?start={start}", Method.GET);
            request.AddHeader("Accept", "application/json");
             request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetAllProductResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<GetProductResponse> GetAllProductById(int id, string token)
        {
            IRestRequest request = new RestRequest($"api/product/{id}", Method.GET);
            request.AddHeader("Accept", "application/json");
             request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetProductResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<ApiResponse> AddProduct(ProductModel product , string token)
        {
            IRestRequest request = new RestRequest("api/product", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(product);
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
        public async Task<ApiResponse> UpdateProduct(ProductModel product ,string token)
        {
            IRestRequest request = new RestRequest("api/product", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(product);
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
