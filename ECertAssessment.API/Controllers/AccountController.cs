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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECertAssessment.API.Models.ApiResponse;

namespace ECertAssessment.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ApiController
    {
        private IAppSettings _settings;
        private readonly JwtProvider _jwtProvider;

        public AccountController(IAppSettings appSettings)
        {
            _settings = appSettings;
            _jwtProvider = new JwtProvider(_settings); ;
        }

        [HttpPost]
        public async Task<ApiResponse> Register(CreateAppUserCommand command)
        {
            var apiResponse = new ApiResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var user = await Mediator.Send(command);
                    apiResponse.ResponseMessage = user;
                    apiResponse.ResponseType = 1;
                
                return apiResponse;
            }
            catch (Exception)
            {

                return apiResponse;
            }
        }

        [HttpGet]
        [Route("login/{email}/{password}")]
        public async Task<LoginUserResponse> LoginUser(string email , string password)
        {
            var apiResponse = new LoginUserResponse { ResponseMessage = "Failed", ResponseType = -1 };
            try
            {
                var user = await Mediator.Send(new GetAppUserQuery {  Email = email , Password = password});
                if (user != null)
                {
                    var userResponse = new UserLoginModel();
                    userResponse.Email = user.Email;
                    userResponse.Id = user.Id;
                    var token = _jwtProvider.GetTokenResponse(user.Email, user);
                    userResponse.Token = token.Token;
                    apiResponse.ResponseType = 1;
                    apiResponse.ResponseMessage = "Success";
                    apiResponse.ResponseObject = userResponse;
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
