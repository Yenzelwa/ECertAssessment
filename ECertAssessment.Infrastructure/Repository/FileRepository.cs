
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
    public class FileRepository : IFileRepository
    {

        private ecertdbContext _dataContext;

        public FileRepository(ecertdbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Add(File entity)
        {
            try
            {
                var appUserResult = await _dataContext.Files.Where(x => x.FileName == entity.FileName).FirstOrDefaultAsync();
                if (appUserResult != null)
                {
                    return "Error File already exists.";
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

        public async Task<File> Get(int id)
        {
            return await _dataContext.Files.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<File>> GetAll()
        {
            return await _dataContext.Files.Include(c => c.CreateByNavigation).ToListAsync();
        }

        public Task<string> Update(File entity)
        {
            throw new NotImplementedException();
        }
    }
}
