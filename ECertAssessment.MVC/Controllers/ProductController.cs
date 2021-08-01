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
using static ECertAssessment.MVC.Models.DTParameters;

namespace ECertAssessment.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService  _categoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> GetData([FromBody] DtParameters dtParameters)
        {

            var start = dtParameters.start;
            var token = Request.Cookies["token"];
            var products = await _productService.GetAllProducts(token , start);
            if (products.ResponseType > 0)
            {
                   return Json(new
                {
                    draw = dtParameters.draw,
                    recordsTotal = products.NumberOfProducts,
                    recordsFiltered = products.NumberOfProducts,
                       data = products.ResponseObject
                   });
            }
            else
            {
                return Json(new { data = products.ResponseObject });
            }


        }
        public async Task<IActionResult> Create()
        {
            var token = Request.Cookies["token"];
            var request = new ApiRequest { Start = 1, Length = 10 };
            var _category = await _categoryService.GetAllCategories(token);
            if (_category != null)
            {
                ViewBag.Category = _category.ResponseObject.Select(tier => new SelectListItem
                {
                    Text = tier.Name,
                    Value = tier.CategoryId.ToString()
                });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel  product , IFormFile file)
        {
            var userId = Request.Cookies["userId"];
            var token = Request.Cookies["token"];
            if (file != null && file.Length > 0)
            {
                var filename = file.FileName;
                product.CategoryId = 1;
                using (var fileStream = file.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    product.Image = Convert.ToBase64String(fileBytes,0,fileBytes.Length);
                }

            }
            product.CreatedBy = Convert.ToInt32(userId);
            var _product = await _productService.AddProduct(product, token);
            if (_product.ResponseType > 0)
            {
                return Redirect("Index");
            }

            var _category = await _categoryService.GetAllCategories(token);
            ViewBag.Category = _category.ResponseObject.Select(tier => new SelectListItem
            {
                Text = tier.Name,
                Value = tier.CategoryId.ToString()
            });
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var request = new ApiRequest { Start = 1, Length = 10 };
            var token = Request.Cookies["token"];
            var _category = await _categoryService.GetAllCategories(token);
            if (_category != null)
            {
                ViewBag.Category = _category.ResponseObject.Select(tier => new SelectListItem
                {
                    Text = tier.Name,
                    Value = tier.CategoryId.ToString()
                });
            }
            var model = await _productService.GetAllProductById(id,token);

            return View(model.ResponseObject);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            var token = Request.Cookies["token"];
            var userId = Request.Cookies["userId"];
            product.CreatedBy = Convert.ToInt32(userId);
            var _product = await _productService.UpdateProduct(product,token);
            if (_product.ResponseType > 0)
            {
                return Redirect("Index");
            }


            return View();
        }

        public class ByteArrayConverter : System.Text.Json.Serialization.JsonConverter<byte[]>
        {
            public override byte[] Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
            {
                short[] sByteArray = System.Text.Json.JsonSerializer.Deserialize<short[]>(ref reader);
                byte[] value = new byte[sByteArray.Length];
                for (int i = 0; i < sByteArray.Length; i++)
                {
                    value[i] = (byte)sByteArray[i];
                }

                return value;
            }

            public override void Write(System.Text.Json.Utf8JsonWriter writer, byte[] value, System.Text.Json.JsonSerializerOptions options)
            {
                writer.WriteStartArray();

                foreach (var val in value)
                {
                    writer.WriteNumberValue(val);
                }

                writer.WriteEndArray();
            }
        }
    }
}
