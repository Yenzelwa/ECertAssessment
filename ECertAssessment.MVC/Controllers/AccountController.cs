using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECertAssessment.MVC.API.Service;
using ECertAssessment.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECertAssessment.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccontService _accontService;

        public AccountController()
        {
            _accontService = new AccontService();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountModel account)
        {
            var _account = await _accontService.Login(account);
            if (_account.ResponseMessage == "Success")
            {
                Response.Cookies.Append("token", _account.ResponseObject.Token.access_token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                Response.Cookies.Append("userId", _account.ResponseObject.Id.ToString(), new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AccountModel account)
        {
            var _account = await _accontService.Register(account);
            if (_account.ResponseType > 0)
            {
                return View();
            }

            return View();
        }

    }
}
