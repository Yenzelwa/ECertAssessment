using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ECertAssessment.MVC.API.Service;
using ECertAssessment.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECertAssessment.MVC.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly CategoryService  _categoryService;
        private readonly INotyfService _notyf;
       
        public CategoryController(INotyfService notyfService)
        {
            _categoryService = new CategoryService();
            _notyf = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> GetData()
        {
            var token = Request.Cookies["token"];
            var Categorys = await _categoryService.GetAllCategories(token);
            if (Categorys.ResponseType > 0)
            {
                return Json(new { data = Categorys.ResponseObject });
            }
            else
            {
                return Json(new { data = Categorys.ResponseObject });
            }


        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel  category)
        {
            Regex regexObj = new Regex(@"^[A-Z]{3}\d{3}$", RegexOptions.Multiline);
           var foundMatch = regexObj.IsMatch(category.CategoryCode);
            if (!foundMatch)
            {
                _notyf.Error("Invalid Category");
                return View();
            }
            var userId = Request.Cookies["userId"];
            var token = Request.Cookies["token"];
            category.CreatedBy = Convert.ToInt32(userId);
            var _category = await _categoryService.AddCategory(category,token);
            if (_category.ResponseType > 0)
            {
                return Redirect("Index");
            }
            _notyf.Error("Error Occured");
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var token = Request.Cookies["token"];
            var model = await _categoryService.GetAllCategoryById(id,token);

            return View(model.ResponseObject);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            var token = Request.Cookies["token"];
            Regex regexObj = new Regex(@"^[A-Z]{3}\d{3}$", RegexOptions.Multiline);
            var foundMatch = regexObj.IsMatch(category.CategoryCode);
            if (!foundMatch)
            {
                _notyf.Error("Invalid Category");
                return View();
            }
            var _category = await _categoryService.UpdateCategory(category,token);
            if (_category.ResponseType > 0)
            {
                return Redirect("Index");
            }

            _notyf.Error("Error Occured");
            return View();
        }
    }
}
