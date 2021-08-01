using System.Data.Entity;
using System.Linq;
using ECertAssessment.BLL.Models;

namespace ECertAssessment.BLL.Data.Repositories
{
    public class CustomerRepository : Repository<Product>, IProductRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }

     
    }
}