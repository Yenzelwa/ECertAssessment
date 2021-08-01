
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECertAssessment.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private ecertdbContext _dataContext;

        public CategoryRepository(ecertdbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Add(Category entity)
        {
            try
            {
                var appUserResult = await _dataContext.Categories.Where(x => x.Name == entity.Name).FirstOrDefaultAsync();
                if (appUserResult != null)
                {
                    return "Error category already exists.";
                }
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

        public async Task<Category> Get(int id)
        {
            return await _dataContext.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dataContext.Categories.Include(c=>c.CreatedByNavigation).ToListAsync();
        }


        public async Task<string> Update(Category entity)
        {
            try
            {
                var category = await _dataContext.Categories.Where(x => x.CategoryId == entity.CategoryId).FirstOrDefaultAsync();
                if (category != null)
                {
                    category.Name = entity.Name;
                    category.CategoryCode = entity.CategoryCode;
                    category.IsActive = entity.IsActive;
                    _dataContext.SaveChanges();
                    return "Success";
                    
                }
                return "Error category doesn't exists.";



            }
            catch (Exception e)
            {
                return "An Error has occured";
            }
        }
    }
}
