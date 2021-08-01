
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECertAssessment.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private ecertdbContext _dataContext;

        public ProductRepository(ecertdbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Add(Product entity)
        {
            try
            {
                var appUserResult = await _dataContext.Products.Where(x => x.Name == entity.Name).FirstOrDefaultAsync();
                string productCode = "001";
                var lastProduct = await _dataContext.Products.OrderByDescending(x => x.ProductId).FirstOrDefaultAsync();
                if (lastProduct != null)
                {
                    var number = Convert.ToInt32(lastProduct.ProductCode.Substring(lastProduct.ProductCode.LastIndexOf('-') + 1));
                    number++;
                    productCode = number.ToString().PadLeft(3, '0');
                }
                if (appUserResult != null)
                {
                    return "Error product already exists.";
                }
                entity.ProductCode = DateTime.Now.ToString("yyyyMM-") + productCode;
                entity.DateCreated = DateTime.Now;
                _dataContext.Add(entity);
                _dataContext.SaveChanges();
                return "Success";


            }
            catch (Exception e)
            {
                return "An Error has occured";
            }
        }

        public async Task<Product> Get(int id)
        {
            return await _dataContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dataContext.Products
                .ToListAsync();
        }


        public async Task<int> GetAllCount()
        {
            return await _dataContext.Products.CountAsync();
        }

        public async Task<IEnumerable<Product>> GetAllFilter(int start, int length)
        {
            return await _dataContext.Products.Include(c => c.CreatedByNavigation).Include(p => p.Category)
                  .Skip(start)
                .Take(length)
              .ToListAsync();
        }

        public async Task<string> Update(Product entity)
        {
            try
            {
                var category = await _dataContext.Products.Where(x => x.ProductId == entity.ProductId).FirstOrDefaultAsync();
                if (category != null)
                {
                    category.Name = entity.Name;
                    category.ProductCode = entity.ProductCode;
                    category.CategoryId = entity.CategoryId;
                    category.Description = entity.Description;
                    category.Price = entity.Price;
                    category.Image = entity.Image;
                    _dataContext.SaveChanges();
                    return "Success";

                }
                return "Error product doesn't exists.";



            }
            catch (Exception e)
            {
                return "An Error has occured";
            }
        }
    }
    
}
