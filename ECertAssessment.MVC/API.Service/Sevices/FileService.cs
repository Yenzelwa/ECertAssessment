
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
    public class FileService
    {

        public async Task<GetAllFileResponse> GetAllFiles(string token)
        {
            IRestRequest request = new RestRequest($"api/file", Method.GET);
            request.AddHeader("Accept", "application/json");
             request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetAllFileResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<ApiResponse> AddFile(FileModel file , string token)
        {
            IRestRequest request = new RestRequest("api/file", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(file);
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
        public async Task<GetFileByIdResponse> GetFileById(int id ,string token)
        {
            IRestRequest request = new RestRequest($"api/file/{id}", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            var response = await RestECert.ExecuteAsync<GetFileByIdResponse>(request);
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
