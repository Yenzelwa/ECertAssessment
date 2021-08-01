
using ECertAssessment.Application.Interfaces;
using ECertAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUser.Infrastructure.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private ecertdbContext _dataContext;

        public AppUserRepository(ecertdbContext  dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> AddUser(AspNetUser entity)
        {
            try
            {
                var appUserResult = await _dataContext.AspNetUsers.Where(x => x.Email == entity.Email).FirstOrDefaultAsync();
                if (appUserResult != null)
                {
                    return "Error user already exists.";
                }

                    _dataContext.Add(entity);
                    _dataContext.SaveChanges();
                return "Success";
                 

            }
            catch (Exception e)
            {
                return "An Error has occured"; 
            }
        }

        public async Task<AspNetUser> LoginUser(string email, string password)
        {
          return  await _dataContext.AspNetUsers.Where(x => x.Email == email && x.PasswordHash == password).FirstOrDefaultAsync();
            
        }
    }
}
