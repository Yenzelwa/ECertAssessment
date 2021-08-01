
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
    public class AccontService
    {

        public async Task<UserLoginResponse> Login(AccountModel account)
        {
            IRestRequest request = new RestRequest($"api/account/login/{account.Email}/{account.PasswordHash}", Method.GET);
            request.AddHeader("Accept", "application/json");
            // request.AddHeader("Authorization", $"Bearer {token}");
          //  request.AddJsonBody(account);
            var response = await RestECert.ExecuteAsync<UserLoginResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;

        }
        public async Task<ApiResponse> Register(AccountModel  account)
        {
            IRestRequest request = new RestRequest("api/account", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(account);
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
