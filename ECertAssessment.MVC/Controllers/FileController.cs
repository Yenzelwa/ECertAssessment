using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECertAssessment.MVC.API.Service;
using ECertAssessment.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;

namespace ECertAssessment.MVC.Controllers
{
    public class FileController : Controller
    {
        private readonly FileService _fileService;
        private readonly CategoryService  _categoryService;
        public FileController()
        {
            _fileService = new FileService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> GetData()
        {
            var request = new ApiRequest{ Start = 1, Length = 10 };
            var token = Request.Cookies["token"];
            var Files = await _fileService.GetAllFiles(token);
            if (Files.ResponseType > 0)
            {
                return Json(new { data = Files.ResponseObject });
            }
            else
            {
                return Json(new { data = Files.ResponseObject });
            }


        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( IFormFile file)
        {
            var File = new FileModel();
            var userId = Request.Cookies["userId"];
            var token = Request.Cookies["token"];
            if (file != null && file.Length > 0)
            {
                var filename = file.FileName;
                using (var fileStream = file.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    File.File1 = Convert.ToBase64String(fileBytes);
                    File.FileName = filename;
                }


                File.CreateBy = Convert.ToInt32(userId);
                var _File = await _fileService.AddFile(File, token);
                if (_File.ResponseType > 0)
                {
                    return Redirect("Index");
                }
            }

            return View();
        }
        public async Task<FileResult> DownloadFile(int id)
        {
            var token = Request.Cookies["token"];
            var file = await _fileService.GetFileById(id,token);
            if (file != null) {
                var filedata = Convert.FromBase64String(file.ResponseObject.File1);
                return File(filedata, MimeTypes.GetMimeType(file.ResponseObject.FileName), file.ResponseObject.FileName);
            }
            return null;
        }
    }
}
